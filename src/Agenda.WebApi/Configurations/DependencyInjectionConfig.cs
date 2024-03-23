using Agenda.Data.Interfaces;
using Agenda.Data.Repositories;
using Agenda.Data.UoW;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Services;
using Agenda.Shared.Settings;
using Agenda.WebApi.Controllers.Auth;

namespace Agenda.WebApi.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ITwilioService, TwilioService>();
            services.AddScoped<IVerificationCodeService, VerificationCodeService>();

            // User Default 
            var userDefaultSetting = configuration.GetSection("UserDefault");
            services.Configure<UserDefaultSetting>(userDefaultSetting);

            // User Default
            services.AddOptions<UserDefaultSetting>()
               .BindConfiguration("UserDefault")
               .ValidateDataAnnotations()
               .ValidateOnStart();

            // Twilio
            services.AddOptions<TwilioSetting>()
                .BindConfiguration("Twilio")
                .ValidateDataAnnotations()
                .ValidateOnStart();

            // Verification Code
            services.AddOptions<VerificationCodeSetting>()
                .BindConfiguration("VerificationCode")
                .ValidateDataAnnotations()
                .ValidateOnStart();

            // UoW
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IVerificationCodeRepository, VerificationCodeRepository>();

            // Identity user
            services.AddHttpContextAccessor();
            services.AddScoped<IUser, User>();

            return services;
        }
    }
}
