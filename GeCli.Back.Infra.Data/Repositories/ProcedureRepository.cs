using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class ProcedureRepository : IProcedureRepository
    {
        ApplicationDbContext _procedureContext;
        public ProcedureRepository(ApplicationDbContext context)
        {
            _procedureContext = context;
        }

        public async Task<IEnumerable<Procedure>> GetProcedures()
        {
            return await _procedureContext.Procedures.ToListAsync();

        }

        public async Task<Procedure> GetProcedureById(int? id)
        {
            return await _procedureContext.Procedures.FindAsync(id);
        }

        public async Task<Procedure> Create(Procedure procedure)
        {
            _procedureContext.Procedures.Add(procedure);
            await _procedureContext.SaveChangesAsync();
            return procedure;
        }

        public async Task<Procedure> Update(Procedure procedure)
        {
            _procedureContext.Procedures.Update(procedure);
            await _procedureContext.SaveChangesAsync();
            return procedure;
        }
        public async Task<Procedure> Remove(Procedure procedure)
        {
            _procedureContext?.Procedures.Remove(procedure);
            await _procedureContext.SaveChangesAsync();
            return procedure;
        }
    }
}
