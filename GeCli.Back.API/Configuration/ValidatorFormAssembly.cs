using FluentValidation;
using GeCli.Back.Manager.Validator;

namespace GeCli.Back.API.Configuration
{
    public static class ValidatorFormAssembly
    {
        public static void AddValidatormAssemblyContaining(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<NewCustomerValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCustomerValidator>();

        }
    }
}
