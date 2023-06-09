using FluentValidation;
using FluentValidation.AspNetCore;
using GeCli.Back.Manager.Validator;

namespace GeCli.Back.API.ProgramConfigurations
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfigurations(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<NewCustomerValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCustomerValidator>();
        }
    }
}
