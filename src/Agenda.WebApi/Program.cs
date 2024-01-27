
using Agenda.WebApi.Configurations;

namespace Agenda.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApiConfig();

            builder.Services.AddIdentityConfig(builder.Configuration);

            var app = builder.Build();

            app.UseApiConfig(app.Environment);

            app.Run();
        }
    }
}
