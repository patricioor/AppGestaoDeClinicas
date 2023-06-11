using GeCli.Back.API.ProgramConfigurations;
using GeCli.Back.Infra.Data.Context;
using GeCli.Back.Infra.Data.Identity;
using GeCli.Back.Infra.IoC.DIConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeCli.Back.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<ApplicationDbContext>().
                AddDefaultTokenProviders();

            services.UseDependencyInjectionEntityConfiguration();
            services.AddFluentValidationConfigurations();
            services.UseAutoMapperConfiguration();
        }

        public static void UseInfrastructure(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
