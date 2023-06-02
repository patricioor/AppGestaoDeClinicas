using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IEmploymentService
    {
        Task<IEnumerable<EmploymentDTO>> GetEmploymentsAsync();
        Task<EmploymentDTO> GetEmploymentByIdAsync(int id);

        Task CreateEmploymentAsync(EmploymentDTO employmentDTO);
        Task UpdateEmploymentAsync(EmploymentDTO employmentDTO);
        Task DeleteEmploymentAsync(int id);
    }
}
