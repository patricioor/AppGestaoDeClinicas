using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IProcedureService
    {
        Task<IEnumerable<ProcedureDTO>> GetProcedures();
        Task<ProcedureDTO> GetProcedureById(int? id);

        Task Create(ProcedureDTO procedureDTO);
        Task Update(ProcedureDTO procedureDTO);
        Task Delete(int? id);
    }
}
