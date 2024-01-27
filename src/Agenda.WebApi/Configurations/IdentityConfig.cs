using Agenda.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Agenda.WebApi.Configurations
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<AgendaAuthDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<AgendaAuthDbContext>()
               .AddDefaultTokenProviders();

            // Jwt configs 
            var jwtConfigSection = configuration.GetSection("Jwt");
            services.Configure<JwtConfig>(jwtConfigSection);

            var jwtConfig = jwtConfigSection.Get<JwtConfig>();
            var key = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtConfig.ValidoEm,
                    ValidIssuer = jwtConfig.Emissor
                };
            });

            return services;
        }
    }
}
