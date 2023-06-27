using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class ConsumableRepository : IConsumableRepository
    {
        ApplicationDbContext _consumableContext;
        public ConsumableRepository(ApplicationDbContext context)
        {
            _consumableContext = context;
        }

        public async Task<ICollection<Consumable>> GetConsumablesAsync()
        {
            return await _consumableContext.Consumables.AsNoTracking().ToListAsync();
        }

        public async Task<Consumable> GetConsumableByIdAsync(int id)
        {
            return await _consumableContext.Consumables.FindAsync(id);
        }

        public async Task<Consumable> Create(Consumable consumable)
        {
            _consumableContext.Consumables.Add(consumable);
            await _consumableContext.SaveChangesAsync();
            return consumable;
        }

        public async Task<Consumable> Update(Consumable consumable)
        {
            _consumableContext.Update(consumable);
            await _consumableContext.SaveChangesAsync();
            return consumable;
        }
        public async Task<Consumable> Delete(Consumable consumable)
        {
            _consumableContext.Remove(consumable);
            await _consumableContext.SaveChangesAsync();
            return consumable;
        }
    }
}
