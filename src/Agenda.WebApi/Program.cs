
using Agenda.WebApi.Configurations;

namespace Agenda.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApiConfig(builder.Configuration);

            builder.Services.AddIdentityConfig(builder.Configuration);

            builder.Services.AddSwaggerConfig();

            builder.Services.RegisterMediatR();

            builder.Services.ResolveDependencies();

            var app = builder.Build();

            app.UseApiConfig(app.Environment);

            app.UseSwaggerConfig();

            app.Run();
        }
    }
}
