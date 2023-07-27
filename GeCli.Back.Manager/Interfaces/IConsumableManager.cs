using GeCli.Back.Shared.ModelView.Consumable;

namespace GeCli.Back.Manager.Interfaces;
public interface IConsumableManager
{
    Task<IEnumerable<ConsumableView>> GetConsumablesAsync();
    Task<ConsumableView> GetConsumableByIdAsync(int id);
    Task<ConsumableView> InsertConsumableAsync(NewConsumable newConsumable);
    Task<ConsumableView> UpdateConsumableAsync(UpdateConsumable updateConsumable);
    Task<ConsumableView> RemoveConsumableAsync(int id);
}
