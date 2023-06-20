using AutoMapper;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Shared.ModelView.CommumClasses;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back.Manager.Mappings
{
    public class NewDentistMappingProfile : Profile
    {
        public NewDentistMappingProfile()
        {
            CreateMap<NewDentist, Dentist>()
                    .ForMember(d => d.CRO, o => o.MapFrom(x => x.CRO.ToUpper()))
                    .ForMember(d => d.CreationDate, o => o.MapFrom(x => DateTime.Now))
                    .ForMember(d => d.BirthDay, o => o.MapFrom(x => x.BirthDay.Date));

            CreateMap<NewAddress, CustomerAddress>();
            CreateMap<NewCellphone, CustomerCellphone>();
        }
    }
}
