using GeCli.Back.Manager.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace GeCli.Back.Infra.IoC.DIConfiguration;
public static class AutoMapperConfig
{
    public static void UseAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(
            //Category
            typeof(CategoryMappingProfile),
            //Consumable
            typeof(ConsumableMappingProfile),
            //Customer
            typeof(CustomerMappingProfile),
            //Dentist
            typeof(DentistMappingProfile),
            //Supplier
            typeof(SupplierMappingProfile),
            //User
            typeof(UserMappingProfile)
            );
    }
}
