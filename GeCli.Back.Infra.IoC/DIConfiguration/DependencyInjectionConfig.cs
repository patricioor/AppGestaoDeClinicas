using GeCli.Back.Domain.Interfaces;
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
            //Category
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();

            //Consumable
            services.AddScoped<IConsumableRepository, ConsumableRepository>();
            services.AddScoped<IConsumableManager, ConsumableManager>();

            //Supplier
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierManager, SupplierManager>();

            //Customer
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            //Dentist
            services.AddScoped<IDentistRepository, DentistRepository>();
            services.AddScoped<IDentistManager, DentistManager>();
            services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
            //User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserManager, UserManager>();
        }
    }
}
