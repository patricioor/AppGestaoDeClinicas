using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IResponsibleService
    {
        Task<IEnumerable<ResponsibleDTO>> GetResponsibleAsync();
        Task<ResponsibleDTO> GetResponsibleByIdAsync(int id);

        Task CreateResponsibleAsync(ResponsibleDTO responsibleDTO);
        Task UpdateResponsibleAsync(ResponsibleDTO responsibleDTO);
        Task DeleteResponsibleAsync(int id);
    }
}
