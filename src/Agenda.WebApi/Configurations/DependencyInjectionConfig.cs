using Agenda.Domain.Interfaces;
using Agenda.Domain.Services;
using Agenda.WebApi.Controllers.Auth;

namespace Agenda.WebApi.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();

            // Identity user
            services.AddHttpContextAccessor();
            services.AddScoped<IUser, User>();

            return services;
        }
    }
}
