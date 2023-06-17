using AutoMapper;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Mappings
{
    public class NewCustomerMappingProfile : Profile
    {
        public NewCustomerMappingProfile()
        {
            CreateMap<NewCustomer, Customer>()
                .ForMember(d => d.CreationDate, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.BirthDay, o=> o.MapFrom(x => x.BirthDay.Date));

            CreateMap<NewAddress, Address>();
        }
    }
}
