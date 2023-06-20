using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back.Manager.Interfaces
{
    public interface IDentistManager
    {
        Task<IEnumerable<Dentist>> GetDentistsAsync();
        Task<Dentist> GetDentistByIdAsync(int id);

        Task<Dentist> InsertDentistAsync(NewDentist newDentist);
        Task<Dentist> UpdateDentistAsync(UpdateDentist updateDentist);
        Task DeleteDentistAsync(int id);
    }
}
