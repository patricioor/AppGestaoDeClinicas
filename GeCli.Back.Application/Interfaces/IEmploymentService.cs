using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IEmploymentService
    {
        Task<IEnumerable<EmploymentDTO>> GetEmployments();
        Task<EmploymentDTO> GetEmploymentById(int? id);

        Task Create(EmploymentDTO employmentDTO);
        Task Update(EmploymentDTO employmentDTO);
        Task Delete(int? id);
    }
}
