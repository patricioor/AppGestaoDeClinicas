using GeCli.Back.Infra.Data.Services;
using GeCli.Back.Manager.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GeCli.Back.API.Configurations
{
    public static class JwtConfig
    {
        public static void AddJWTConfiguration( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJWTService, JWTService>();

            var key = Encoding.ASCII.GetBytes(configuration.GetSection("JWT:Secret").Value);

            services.AddAuthentication(p =>
                {
                    p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                )
                .AddJwtBearer(p =>
                {
                    p.RequireHttpsMetadata = false;
                    p.SaveToken = true;
                    p.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = configuration.GetSection("JWT:Issuer").Value,
                        ValidateAudience = true,
                        ValidAudience = configuration.GetSection("JWT:Audience").Value,
                        ValidateLifetime = true
                    };
                });
        }

        public static void UseJWTConfiguration(this IApplicationBuilder app) 
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
