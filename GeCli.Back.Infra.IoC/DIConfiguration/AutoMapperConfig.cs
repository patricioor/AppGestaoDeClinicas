using GeCli.Back.Manager.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace GeCli.Back.Infra.IoC.DIConfiguration
{
    public static class AutoMapperConfig
    {
        public static void UseAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                //Customer
                typeof(NewCustomerMappingProfile),
                //Dentist
                typeof(NewDentistMappingProfile)
                );
        }
    }
}
