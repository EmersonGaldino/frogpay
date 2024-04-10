using System;
using frogpay.application.AppService.User;
using frogpay.application.Interface.User;
using frogpay.bootstrapper.Configurations.Security;
using frogpay.domain.Repositories.IRepository.User;
using frogpay.domain.Service.User;
using frogpay.repository.context;
using frogpay.repository.User;
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

        #region .::AppServices

        services.AddScoped<IUserAppService, UserAppService>();

        #endregion

        #region .::Services

        services.AddScoped<IUserService, UserService>();

        #endregion

        #region .::Repositories

        services.AddScoped<IUserRepository, UserRepository>();

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