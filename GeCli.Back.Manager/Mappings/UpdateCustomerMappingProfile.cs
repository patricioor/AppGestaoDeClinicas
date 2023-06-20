using AutoMapper;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Mappings
{
    public class UpdateCustomerMappingProfile : Profile
    {
        public UpdateCustomerMappingProfile()
        {
            CreateMap<UpdateCustomer, Customer>()              
                .ForMember(d => d.LastUpdate, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.BirthDay, o => o.MapFrom(x => x.BirthDay.Date));
        }
    }
}
