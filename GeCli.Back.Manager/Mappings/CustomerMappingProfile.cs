﻿using AutoMapper;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Shared.ModelView.CommunClasses;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Mappings
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            //Insert
            CreateMap<NewCustomer, Customer>()
                .ForMember(d => d.CreationDate, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.BirthDay, o => o.MapFrom(x => x.BirthDay.Date));

            CreateMap<Customer, CustomerView>().ReverseMap();

            CreateMap<CustomerAddressView, CustomerAddress>().ReverseMap();
            CreateMap<NewCustomerAddress, CustomerAddress>();

            CreateMap<CustomerCellphoneView, CustomerCellphone>().ReverseMap();
            CreateMap<NewCustomerCellphone, CustomerCellphone>();

            CreateMap<CustomerView, NewGender>().ReverseMap();

            //Update
            CreateMap<UpdateCustomer, Customer>()
                .ForMember(d => d.LastUpdate, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.BirthDay, o => o.MapFrom(x => x.BirthDay.Date));
        }
    }
}
