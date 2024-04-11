using System;
using frogpay.application.AppService.Account;
using frogpay.application.AppService.Address;
using frogpay.application.AppService.User;
using frogpay.application.Interface.Account;
using frogpay.application.Interface.Address;
using frogpay.application.Interface.User;
using frogpay.bootstrapper.Configurations.Environments;
using frogpay.bootstrapper.Configurations.Performance.Filters;
using frogpay.bootstrapper.Configurations.Security;
using frogpay.domain.Repositories.IRepository.Account;
using frogpay.domain.Repositories.IRepository.Address;
using frogpay.domain.Repositories.IRepository.User;
using frogpay.domain.Service.Account;
using frogpay.domain.Service.Address;
using frogpay.domain.Service.User;
using frogpay.repository.Account;
using frogpay.repository.Address;
using frogpay.repository.context;
using frogpay.repository.Pagination;
using frogpay.repository.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace frogpay.bootstrapper.Configurations.Injections;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile(EnvironmentsHelper.Development ? "appsettings.Development.json"
                : EnvironmentsHelper.Docker
                    ? "appsettings.Docker.json"
                    : "appsettings.Production.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        
        #region .::Include injection configurations token

        var tokenConfig = new TokenConfig();
        new ConfigureFromConfigurationOptions<TokenConfig>(configuration.GetSection("TokenConfig"))
            .Configure(tokenConfig);
        services.AddSingleton(tokenConfig);

        #endregion
        
        #region .:: Configuration filter performace

        services.AddTransient<PerformaceFilters>();
        services.AddMvc(options => options.Filters.AddService<PerformaceFilters>())
            .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true)
            .SetCompatibilityVersion(CompatibilityVersion.Latest);
        #endregion

        #region .::AppServices

        services.AddScoped<IUserAppService, UserAppService>();
        services.AddScoped<IAccountAppService, AccountAppService>();
        services.AddScoped<IAddressAppService, AddressAppService>();
        #endregion

        #region .::Services

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IAddressService, AddressService>();
        #endregion

        #region .::Repositories

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<Pagination>();
        #endregion

        #region .::UnitOfWork

        services.AddScoped<ContextDb>();

        #endregion

        return services;
    }

    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<ContextDb>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}