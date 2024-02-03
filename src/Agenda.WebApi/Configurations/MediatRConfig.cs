namespace Agenda.WebApi.Configurations
{
    public static class MediatRConfig
    {
        public static IServiceCollection RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(x =>
            {
                x.Lifetime = ServiceLifetime.Scoped;
                x.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            return services;
        }
    }
}
