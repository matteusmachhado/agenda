using Agenda.Domain.Features;

namespace Agenda.WebApi.Configurations
{
    public static class MediatRConfig
    {
        public static void RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(x =>
            {
                x.Lifetime = ServiceLifetime.Scoped;
                x.RegisterServicesFromAssemblies(typeof(BaseCommandHandler).Assembly);
            });
        }
    }
}
