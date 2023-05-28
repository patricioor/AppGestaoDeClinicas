using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IResponsibleService
    {
        Task<IEnumerable<ResponsibleDTO>> GetResponsible();
        Task<ResponsibleDTO> GetResponsibleById(int? id);

        Task Create(ResponsibleDTO responsibleDTO);
        Task Update(ResponsibleDTO responsibleDTO);
        Task Delete(int? id);
    }
}
