using AutoMapper;
using GeCli.Back.Domain.Entities.Employees;
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

            CreateMap<Dentist, DentistView>();
            CreateMap<SpecialtyReference, Specialty>().ReverseMap();
            CreateMap<SpecialtyView, Specialty>().ReverseMap();

            CreateMap<DentistAddressView, DentistAddress>().ReverseMap();
            CreateMap<NewDentistAddress, DentistAddress>();

            CreateMap<DentistCellphoneView, DentistCellphone>().ReverseMap();
            CreateMap<NewDentistCellphone, DentistCellphone>();

            CreateMap<UpdateDentist, Dentist>()
                .ForMember(d => d.LastUpdate, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.BirthDay, o => o.MapFrom(x => x.BirthDay.Date))
                .ReverseMap();
        }
    }
}
