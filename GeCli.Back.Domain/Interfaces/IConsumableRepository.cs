using GeCli.Back.Domain.Entities.Consumables;

namespace GeCli.Back.Domain.Interfaces;
public interface IConsumableRepository
{
    Task<ICollection<Consumable>> GetConsumablesAsync();
    Task<Consumable> GetConsumableByIdAsync(int id);
    Task<Consumable> InsertConsumableAsync(Consumable consumable);
    Task<Consumable> UpdateConsumableAsync(Consumable consumable);
    Task<Consumable> DeleteConsumableAsync(int id);
}
