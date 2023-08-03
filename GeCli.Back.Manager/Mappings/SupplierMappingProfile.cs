using AutoMapper;
using GeCli.Back.Domain.Entities.Suppliers;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.Back.Manager.Mappings
{
    public class SupplierMappingProfile : Profile
    {
        public SupplierMappingProfile()
        {
            //Insert
            CreateMap<NewSupplier, Supplier>();
            CreateMap<Supplier, SupplierView>();

            CreateMap<SupplierAddressView, SupplierAddress>().ReverseMap();
            CreateMap<NewSupplierAddress, SupplierAddress>().ReverseMap();

            CreateMap<SupplierCellphoneView, SupplierCellphone>().ReverseMap();
            CreateMap<NewSupplierCellphone, SupplierCellphone>();

            //Update
            CreateMap<UpdateSupplier, Supplier>();
        }
    }
}
