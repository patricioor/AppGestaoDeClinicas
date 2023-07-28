using GeCli.Back.Domain.Entities.Suppliers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories;

public class SupplierRepository : ISupplierRepository
{
    readonly ApplicationDbContext _context;
    public SupplierRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ICollection<Supplier>> GetSuppliersAsync()
    {
        return await _context.Suppliers
                             .Include( p => p.Address)
                             .Include( p => p.Cellphones)
                             .Include( p => p.Consumables)
                             .AsNoTracking().ToListAsync();
    }

    public async Task<Supplier> GetSupplierByIdAsync(int id)
    {
        return await _context.Suppliers
                     .Include(p => p.Address)
                     .Include(p => p.Cellphones)
                     .Include(p => p.Consumables)
                     .AsNoTracking()
                     .SingleOrDefaultAsync( p => p.Id == id);
    }

    public async Task<Supplier> InsertSupplierAsync(Supplier supplier)
    {
        await InsertConsumableSupplier(supplier);
        await InsertSupplierAsync(supplier);
    }

    public Task<Supplier> UpdateSupplierAsync(Supplier supplier)
    {
        throw new NotImplementedException();
    }
    public Task<Supplier> DeleteSupplierAsync(int id)
    {
        throw new NotImplementedException();
    }
}
