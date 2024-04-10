using System;
using frogpay.application.AppService.Account;
using frogpay.application.AppService.User;
using frogpay.application.Interface.Account;
using frogpay.application.Interface.User;
using frogpay.bootstrapper.Configurations.Performance.Filters;
using frogpay.bootstrapper.Configurations.Security;
using frogpay.domain.Repositories.IRepository.Account;
using frogpay.domain.Repositories.IRepository.User;
using frogpay.domain.Service.Account;
using frogpay.domain.Service.User;
using frogpay.repository.Account;
using frogpay.repository.context;
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
        #endregion

        #region .::Services

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        #endregion

        #region .::Repositories

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
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