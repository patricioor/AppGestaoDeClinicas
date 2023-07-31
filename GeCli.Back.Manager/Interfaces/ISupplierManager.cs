using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.Back.Manager.Interfaces;

public interface ISupplierManager
{
    Task<ICollection<SupplierView>> GetSuppliersAsync();
    Task<SupplierView> GetSupplierByIdAsync(int id);
    Task<SupplierView> InsertSupplierAsync(NewSupplier supplier);
    Task<SupplierView> UpdateSupplierAsync(UpdateSupplier supplier);
    Task<SupplierView> DeleteSupplierAsync(int id);
}
