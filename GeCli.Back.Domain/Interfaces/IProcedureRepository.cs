using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IProcedureRepository
    {
        Task<ICollection<Procedure>> GetProceduresAsync();
        Task<Procedure> GetProcedureByIdAsync(int id);

        Task<Procedure> Create(Procedure procedure);
        Task<Procedure> Update(Procedure procedure);
        Task<Procedure> Remove(Procedure procedure);
    }
}
