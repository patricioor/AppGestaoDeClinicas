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
        public static void UseDependencyInjectionEntityConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticate, AuthenticateService>();

            //Category
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            //Customer
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            //Dentist
            services.AddScoped<IDentistRepository, DentistRepository>();
            services.AddScoped<IDentistManager, DentistManager>();
        }
    }
}
