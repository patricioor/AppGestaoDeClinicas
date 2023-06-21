using AutoMapper;
using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back.Manager.Mappings
{
    public class UpdateDentistMappingProfile : Profile
    {
        public UpdateDentistMappingProfile()
        {
            CreateMap<UpdateDentist, Dentist>()
                .ForMember(d => d.LastUpdate, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.BirthDay, o => o.MapFrom(x => x.BirthDay.Date));
        }
    }
}
