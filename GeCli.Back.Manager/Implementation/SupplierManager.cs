using AutoMapper;
using GeCli.Back.Domain.Entities.Suppliers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.Back.Manager.Implementation;

public class SupplierManager : ISupplierManager
{
    readonly ISupplierRepository _supplierRepository;
    readonly IMapper _mapper;
    public SupplierManager(ISupplierRepository supplierRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<SupplierView>> GetSuppliersAsync()
    {
        return _mapper.Map<ICollection<SupplierView>>(await _supplierRepository.GetSuppliersAsync());
    }
    public async Task<SupplierView> GetSupplierByIdAsync(int id)
    {
        return _mapper.Map<SupplierView>(await _supplierRepository.GetSupplierByIdAsync(id));
    }

    public async Task<SupplierView> InsertSupplierAsync(NewSupplier newSupplier)
    {
        var supplier = _mapper.Map<Supplier>(newSupplier);
        return _mapper.Map<SupplierView>(await _supplierRepository.InsertSupplierAsync(supplier));
    }

    public async Task<SupplierView> UpdateSupplierAsync(UpdateSupplier updateSupplier)
    {
        var supplier = _mapper.Map<Supplier>(updateSupplier);
        return _mapper.Map<SupplierView>(await _supplierRepository.UpdateSupplierAsync(supplier));
    }
    public async Task<SupplierView> DeleteSupplierAsync(int id)
    {
        var supplierDeleted = await _supplierRepository.DeleteSupplierAsync(id);
        return _mapper.Map<SupplierView>(supplierDeleted);
    }
}
