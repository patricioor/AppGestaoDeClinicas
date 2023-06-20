using GeCli.Back.Domain.Entities.Employees;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IDentistRepository
    {
        Task<IEnumerable<Dentist>> GetDentistsAsync();
        Task<Dentist> GetDentistByIdAsync(int id);

        Task<Dentist> InsertDentistAsync(Dentist dentist);
        Task<Dentist> UpdateDentistAsync(Dentist dentist);
        Task DeleteDentistAsync(int id);
    }
}
