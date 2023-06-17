using FluentValidation;
using FluentValidation.AspNetCore;
using GeCli.Back.Manager.Validator;
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

            services.AddValidatorsFromAssemblyContaining<NewCustomerValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCustomerValidator>();
            services.AddValidatorsFromAssemblyContaining<NewAddressValidator>();
        }
    }
}
