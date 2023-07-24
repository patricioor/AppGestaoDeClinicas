using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class ConsumableRepository : IConsumableRepository
    {
        ApplicationDbContext _consumableContext;
        public ConsumableRepository(ApplicationDbContext context)
        {
            _consumableContext = context;
        }

        public async Task<IEnumerable<Consumable>> GetConsumablesAsync()
        {
            return await _consumableContext.Consumables
                .Include(p => p.CategoryId)
                .Include(p => p.Category)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Consumable> GetConsumableByIdAsync(int id)
        {
            return await _consumableContext.Consumables
                .Include(p => p.CategoryId)
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Consumable> InsertConsumableAsync(Consumable consumable)
        {
            _consumableContext.Consumables.Add(consumable);
            await _consumableContext.SaveChangesAsync();
            return consumable;
        }

        public async Task<Consumable> UpdateConsumableAsync(Consumable consumable)
        {
            var consumableInsert = await _consumableContext.Consumables
                .Include(p => p.CategoryId)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == consumable.Id);

            if (consumableInsert != null)
                return null;

            _consumableContext.Entry(consumableInsert).CurrentValues.SetValues(consumable);
            await _consumableContext.SaveChangesAsync();
            return consumable;
        }
        public async Task<Consumable> DeleteConsumableAsync(int id)
        {
            var customerFound = await _consumableContext.Consumables.FindAsync(id);

            if (customerFound != null)
                return null;

            var consumableRemoved = _consumableContext.Consumables.Remove(customerFound);
            await _consumableContext.SaveChangesAsync();
            return consumableRemoved.Entity;
        }
    }
}
