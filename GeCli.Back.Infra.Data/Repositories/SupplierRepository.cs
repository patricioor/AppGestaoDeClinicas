using GeCli.Back.Domain.Entities.Consumables;
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
                             .Include(p => p.Address)
                             .Include(p => p.Cellphones)
                             .Include(p => p.Consumables)
                             .AsNoTracking().ToListAsync();
    }

    public async Task<Supplier> GetSupplierByIdAsync(int id)
    {
        return await _context.Suppliers
                     .Include(p => p.Address)
                     .Include(p => p.Cellphones)
                     .Include(p => p.Consumables)
                     .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Supplier> InsertSupplierAsync(Supplier supplier)
    {
        await InsertSupplierCellphone(supplier);
        await _context.Suppliers.AddAsync(supplier);
        await _context.SaveChangesAsync();
        return supplier;
    }

    private async Task InsertSupplierCellphone(Supplier supplier)
    {
        var supplierCellphone = new List<SupplierCellphone>();
        foreach(var cellphone in supplier.Cellphones)
        {
            var cellphoneConsulted = await _context.SupplierCellphones.FindAsync(cellphone.SupplierId, cellphone.Number);
            if(cellphoneConsulted != null)
                supplierCellphone.Add(cellphoneConsulted);
        }
        supplier.Cellphones = supplierCellphone;
    }

    public async Task<Supplier> UpdateSupplierAsync(Supplier supplier)
    {
        var supplierFound = await _context.Suppliers
                                  .Include(p => p.Address)
                                  .Include(p => p.Cellphones)
                                  .Include(p => p.Consumables)
                                  .SingleOrDefaultAsync(p => p.Id == supplier.Id);

        if (supplierFound == null)
            return null;

        _context.Entry(supplierFound).CurrentValues.SetValues(supplier);
        
        await UpdateSupplierCellphone(supplier, supplierFound);
        await UpdateSupplierConsumable(supplier, supplierFound);
        await _context.SaveChangesAsync();
        return supplierFound;
    }

    private async Task UpdateSupplierConsumable(Supplier supplier, Supplier supplierFound)
    {
        var supplierConsumable = new List<Consumable>();

        foreach(var consumable in supplier.Consumables)
        {
            var consumableFound = await _context.Consumables.FindAsync(consumable.Id);
            if(consumableFound != null)
                supplierConsumable.Add(consumable);
        }

        foreach (var consumableFound in supplierFound.Consumables)
        {
            if (!supplierConsumable.Contains(consumableFound))
                supplierConsumable.Add(consumableFound);
        }
        supplierFound.Consumables.Clear();
        supplierFound.Consumables = supplierConsumable;
    }

    private async Task UpdateSupplierCellphone(Supplier supplier, Supplier supplierFound)
    {
        var supplierCellphone = new List<SupplierCellphone>();
        foreach (var cellphone in supplier.Cellphones)
        {
            var cellphoneFound = await _context.SupplierCellphones.FindAsync(cellphone.SupplierId, cellphone.Number);
            if (cellphoneFound != null)
                supplierCellphone.Add(cellphoneFound);
            else 
                supplierCellphone.Add(cellphone);
        }
        supplierFound.Cellphones = supplierCellphone;
    }
    public async Task<Supplier> DeleteSupplierAsync(int id)
    {
        var supplierFound = await _context.Suppliers.FindAsync(id);

        if (supplierFound == null) return null;

        var supplierRemoved = _context.Suppliers.Remove(supplierFound);
        await _context.SaveChangesAsync();
        return supplierRemoved.Entity;
    }
}
