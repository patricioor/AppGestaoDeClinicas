using GeCli.Back.Domain.Account;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Identity;
using GeCli.Back.Infra.Data.Repositories;
using GeCli.Back.Manager.Implementation;
using GeCli.Back.Manager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GeCli.Back.Infra.IoC.DIConfiguration
{
    public static class DependencyInjectionConfig
    {
        public static void UseDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerManager, CustomerManager>();
        }
    }
}
