
using GeCli.Back.Domain.Account;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using GeCli.Back.Infra.Data.Identity;
using GeCli.Back.Infra.Data.Repositories;
using GeCli.Back.Manager.Implementation;
using GeCli.Back.Manager.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeCli.Back.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<ApplicationDbContext>().
                AddDefaultTokenProviders();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();

            return services;

        }
    }
}
