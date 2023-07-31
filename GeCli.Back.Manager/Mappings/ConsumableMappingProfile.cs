using AutoMapper;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Entities.Consumables;
using GeCli.Back.Shared.ModelView.Category;
using GeCli.Back.Shared.ModelView.Consumable;

namespace GeCli.Back.Manager.Mappings;
public class ConsumableMappingProfile : Profile
{
    public ConsumableMappingProfile()
    {
        //Insert
        CreateMap<NewConsumable, Consumable>();

        CreateMap<Consumable, ConsumableView>();
        CreateMap<CategoryReference, Category>().ReverseMap();
        CreateMap<CategoryView, Category>().ReverseMap();

        //Update
        CreateMap<UpdateConsumable, Consumable>().ReverseMap();
    }
}
