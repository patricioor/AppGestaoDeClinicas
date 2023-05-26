using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IProcedureRepository
    {
        Task<IEnumerable<Procedure>> GetProcedures();
        Task<Procedure> GetProcedureById(int? id);

        Task<Procedure> Create(Procedure procedure);
        Task<Procedure> Update(Procedure procedure);
        Task<Procedure> Remove(Procedure procedure);
    }
}
