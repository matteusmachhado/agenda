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

            // User Default 
            var userDefaultSetting = configuration.GetSection("UserDefault");
            services.Configure<UserDefaultSetting>(userDefaultSetting);

            // Twilio
            var twilioSetting = configuration.GetSection("Twilio");
            services.Configure<TwilioSetting>(twilioSetting);
            
            // UoW
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            // Identity user
            services.AddHttpContextAccessor();
            services.AddScoped<IUser, User>();

            return services;
        }
    }
}
