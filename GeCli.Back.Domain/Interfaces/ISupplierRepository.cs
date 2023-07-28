using GeCli.Back.Domain.Entities.Suppliers;

namespace GeCli.Back.Domain.Interfaces;

public interface ISupplierRepository
{
    Task<ICollection<Supplier>> GetSuppliersAsync();
    Task<Supplier> GetSupplierByIdAsync(int id);
    Task<Supplier> InsertSupplierAsync(Supplier supplier);
    Task<Supplier> UpdateSupplierAsync(Supplier supplier);
    Task<Supplier> DeleteSupplierAsync(int id);
}
