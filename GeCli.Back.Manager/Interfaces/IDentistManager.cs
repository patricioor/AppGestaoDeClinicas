using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back.Manager.Interfaces
{
    public interface IDentistManager
    {
        Task<IEnumerable<DentistView>> GetDentistsAsync();
        Task<DentistView> GetDentistByIdAsync(int id);

        Task<DentistView> InsertDentistAsync(NewDentist newDentist);
        Task<DentistView> UpdateDentistAsync(UpdateDentist updateDentist);
        Task DeleteDentistAsync(int id);
    }
}
