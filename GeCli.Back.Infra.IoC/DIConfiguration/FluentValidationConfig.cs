using FluentValidation;
using FluentValidation.AspNetCore;
using GeCli.Back.Manager.Validator.Customer;
using GeCli.Back.Manager.Validator.Dentist;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace GeCli.Back.API.ProgramConfigurations
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfigurations(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationRulesToSwagger();
            services.AddFluentValidationClientsideAdapters();

            //Customer
            services.AddValidatorsFromAssemblyContaining<NewCustomerValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCustomerValidator>();
            services.AddValidatorsFromAssemblyContaining<NewCustomerAddressValidator>();
            services.AddValidatorsFromAssemblyContaining<NewCustomerCellphoneValidator>();

            //Dentist
            services.AddValidatorsFromAssemblyContaining<NewDentistValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateDentistValidator>();
            services.AddValidatorsFromAssemblyContaining<NewDentistAddressValidator>();
            services.AddValidatorsFromAssemblyContaining<NewDentistCellphoneValidator>();


        }
    }
}
