using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IEmploymentRepository
    {
        Task<IEnumerable<Employment>> GetEmployments();
        Task<Employment> GetEmploymentById(int? id);

        Task<Employment> Create(Employment employment);
        Task<Employment> Update(Employment employment);
        Task<Employment> Remove(Employment employment);
    }
}
