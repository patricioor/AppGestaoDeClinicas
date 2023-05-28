using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IConsumableService
    {
        Task<IEnumerable<ConsumableDTO>> GetConsumables();
        Task<ConsumableDTO> GetConsumableById(int? id);

        Task Create(ConsumableDTO consumableDTO);
        Task Update(ConsumableDTO consumableDTO);
        Task Delete(int? id);
    }
}
