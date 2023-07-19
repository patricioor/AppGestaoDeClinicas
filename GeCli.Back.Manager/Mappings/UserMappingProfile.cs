using AutoMapper;
using GeCli.Back.Domain.Entities.User;
using GeCli.Back.Shared.ModelView.User;

namespace GeCli.Back.Manager.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserView>().ReverseMap();
            CreateMap<User, NewUser>().ReverseMap();
            CreateMap<User, LoggedUser>().ReverseMap();
            CreateMap<Function, FunctionView>().ReverseMap();
            CreateMap<Function, ReferenceFunction>().ReverseMap();
        }
    }
}
