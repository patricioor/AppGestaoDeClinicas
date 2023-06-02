using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IConsumableService
    {
        Task<IEnumerable<ConsumableDTO>> GetConsumablesAsync();
        Task<ConsumableDTO> GetConsumableByIdAsync(int id);

        Task CreateConsumableAsync(ConsumableDTO consumableDTO);
        Task UpdateConsumableAsync(ConsumableDTO consumableDTO);
        Task DeleteConsumableAsync(int id);
    }
}
