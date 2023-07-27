using AutoMapper;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Shared.ModelView.Category;

namespace GeCli.Back.Manager.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<NewCategory, Category>();
        CreateMap<Category, CategoryView>();
        CreateMap<UpdateCategory, Category>();
    }
}
