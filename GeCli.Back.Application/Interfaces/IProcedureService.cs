using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IProcedureService
    {
        Task<IEnumerable<ProcedureDTO>> GetProceduresAsync();
        Task<ProcedureDTO> GetProcedureByIdAsync(int id);

        Task CreateProcedureAsync(ProcedureDTO procedureDTO);
        Task UpdateProcedureAsync(ProcedureDTO procedureDTO);
        Task DeleteProcedureAsync(int id);
    }
}
