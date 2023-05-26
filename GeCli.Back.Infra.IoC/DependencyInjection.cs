using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeCli.Back.Infra.IoC
{
    public static class DependencyInjection
    {
        //public static IServiceCollection AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        //    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        //    services.AddScoped<ICategoryRepository,ICategoryRepository>();
        //    services
        //        int
        //}
    }
}
