using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IDentistRepository
    {
        Task<IEnumerable<Dentist>> GetDentists();
        Task<Dentist> GetDentistById(int? id);

        Task<Dentist> Create(Dentist dentist);
        Task<Dentist> Update(Dentist dentist);
        Task<Dentist> Remove(Dentist dentist);
    }
}
