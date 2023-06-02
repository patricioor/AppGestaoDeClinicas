using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IDentistRepository
    {
        Task<IEnumerable<Dentist>> GetDentistsAsync();
        Task<Dentist> GetDentistByIdAsync(int id);

        Task<Dentist> Create(Dentist dentist);
        Task<Dentist> Update(Dentist dentist);
        Task<Dentist> Remove(Dentist dentist);
    }
}
