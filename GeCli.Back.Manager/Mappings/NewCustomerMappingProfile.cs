using AutoMapper;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Mappings
{
    public class NewCustomerMappingProfile : Profile
    {
        public NewCustomerMappingProfile()
        {
            //Insert
            CreateMap<NewCustomer, Customer>()
                .ForMember(d => d.CreationDate, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.BirthDay, o => o.MapFrom(x => x.BirthDay.Date));

            CreateMap<Customer, CustomerView>();

            CreateMap<CustomerAddressView, CustomerAddress>().ReverseMap();
            CreateMap<NewCustomerAddress, CustomerAddress>();

            CreateMap<CustomerCellphoneView, CustomerCellphone>().ReverseMap();
            CreateMap<NewCustomerCellphone, CustomerCellphone>();

            //Update
            CreateMap<UpdateCustomer, Customer>()
                .ForMember(d => d.LastUpdate, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.BirthDay, o => o.MapFrom(x => x.BirthDay.Date));
        }
    }
}
