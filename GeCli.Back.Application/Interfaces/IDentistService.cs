using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IDentistService
    {
        Task<IEnumerable<DentistDTO>> GetDentists();
        Task<DentistDTO> GetDentistById(int? id);
        Task Create(DentistDTO dentistDTO);
        Task Update(DentistDTO dentistDTO);
        Task Delete(int? id);
    }
}
