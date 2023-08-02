using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Entities.Consumables;
using GeCli.Back.Domain.Entities.Suppliers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories;
public class ConsumableRepository : IConsumableRepository
{
     readonly ApplicationDbContext _consumableContext;
    public ConsumableRepository(ApplicationDbContext context)
    {
        _consumableContext = context;
    }

    public async Task<ICollection<Consumable>> GetConsumablesAsync()
    {
        return await _consumableContext.Consumables            
            .Include(p => p.Category)
            .Include(p => p.Suppliers)
            .AsNoTracking().ToListAsync();
    }

    public async Task<Consumable> GetConsumableByIdAsync(int id)
    {
        return await _consumableContext.Consumables
            .Include(p => p.Category)
            .Include(p => p.Suppliers)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Consumable> InsertConsumableAsync(Consumable consumable)
    {
        await InsertCategoryConsumable(consumable);
        await InsertConsumableSupplier(consumable);
        _consumableContext.Consumables.Add(consumable);
        await _consumableContext.SaveChangesAsync();
        return consumable;
    }

    private async Task InsertConsumableSupplier(Consumable consumable)
    {
        var consumableSupplier = new List<Supplier>();

        foreach(var supplier in consumable.Suppliers)
        {
            var supplierFounded = await _consumableContext.Suppliers.FindAsync(supplier.Id);
            consumableSupplier.Add(supplierFounded);
        }
            consumable.Suppliers = consumableSupplier;
    }

    private async Task InsertCategoryConsumable(Consumable consumable)
    {
        var consumableCategory = await _consumableContext.Categories.FirstAsync(p => p.Id == consumable.Category.Id);
        if (consumableCategory != null)
            consumable.Category = consumableCategory;        
    }

    public async Task<Consumable> UpdateConsumableAsync(Consumable consumable)
    {
        var consumableFound = await _consumableContext.Consumables
            .Include(p => p.Category)
            .Include(p => p.Suppliers)
            .FirstOrDefaultAsync(p => p.Id == consumable.Id);

        if (consumableFound == null)
            return null;

        _consumableContext.Entry(consumableFound).CurrentValues.SetValues(consumable);
        await _consumableContext.SaveChangesAsync();
        return consumable;
    }

    public async Task<Consumable> DeleteConsumableAsync(int id)
    {
        var customerFound = await _consumableContext.Consumables.FindAsync(id);

        if (customerFound == null)
            return null;

        var consumableRemoved = _consumableContext.Consumables.Remove(customerFound);
        await _consumableContext.SaveChangesAsync();
        return consumableRemoved.Entity;
    }
}
