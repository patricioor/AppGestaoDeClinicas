using FluentValidation;
using FluentValidation.AspNetCore;
using GeCli.Back.Manager.Validator;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace GeCli.Back.API.ProgramConfigurations
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfigurations(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationRulesToSwagger();
            services.AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<NewCustomerValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCustomerValidator>();
        }
    }
}
