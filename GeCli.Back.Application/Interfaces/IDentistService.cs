using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IDentistService
    {
        Task<IEnumerable<DentistDTO>> GetDentistsAsync();
        Task<DentistDTO> GetDentistByIdAsync(int id);
        Task CreateDentistAsync(DentistDTO dentistDTO);
        Task UpdateDentistAsync(DentistDTO dentistDTO);
        Task DeleteDentistAsync(int id);
    }
}
