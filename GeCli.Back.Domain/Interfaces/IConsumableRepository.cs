using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IConsumableRepository
    {
        Task<IEnumerable<Consumable>> GetConsumablesAsync();
        Task<Consumable> GetConsumableByIdAsync(int id);

        Task<Consumable> InsertConsumableAsync(Consumable consumable);
        Task<Consumable> UpdateConsumableAsync(Consumable consumable);
        Task<Consumable> DeleteConsumableAsync(int id);
    }
}
