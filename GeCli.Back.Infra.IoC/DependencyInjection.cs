using GeCli.Back.Application.Interfaces;
using GeCli.Back.Application.Mappings;
using GeCli.Back.Application.Services;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using GeCli.Back.Infra.Data.Repositories;
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

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IConsumableRepository, ConsumableRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDentistRepository, DentistRepository>();
            services.AddScoped<IEmploymentRepository, EmploymentRepository>();
            services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddScoped<IProcedureRepository, ProcedureRepository>();
            services.AddScoped<IResponsibleRepository, ResponsibleRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IConsumableService, ConsumableService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDentistService, DentistService>();
            services.AddScoped<IEmploymentService, EmploymentService>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IProcedureService, ProcedureService>();
            services.AddScoped<IResponsibleService, ResponsibleService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("GeCli.Back.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));

            return services;

        }
    }
}
