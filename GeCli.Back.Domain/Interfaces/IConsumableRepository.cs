using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IConsumableRepository
    {
        Task<IEnumerable<Consumable>> GetConsumablesAsync();
        Task<Consumable> GetConsumableByIdAsync(int id);

        Task<Consumable> Create(Consumable consumable);
        Task<Consumable> Update(Consumable consumable);
        Task<Consumable> Delete(Consumable consumable);
    }
}
