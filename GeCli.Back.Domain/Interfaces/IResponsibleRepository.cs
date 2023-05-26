using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IResponsibleRepository
    {
        Task<IEnumerable<Responsible>> GetResponsibles();
        Task<Responsible> GetResponsiblesById(int? Id);

        Task<Responsible> Create(Responsible responsible);
        Task<Responsible> Update(Responsible responsible);
        Task<Responsible> Remove(Responsible responsible);
    }
}
