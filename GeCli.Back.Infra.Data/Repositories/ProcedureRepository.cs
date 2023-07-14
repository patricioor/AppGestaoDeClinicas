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

        public async Task<ICollection<Procedure>> GetProceduresAsync()
        {
            return await _procedureContext.Procedures.AsNoTracking().ToListAsync();

        }

        public async Task<Procedure> GetProcedureByIdAsync(int id)
        {
            return await _procedureContext.Procedures.FindAsync(id);
        }

        public async Task<Procedure> Create(Procedure procedure)
        {
            _procedureContext.Procedures.Add(procedure);
            await InsertConsumablesProcedure(procedure);
            await _procedureContext.SaveChangesAsync();
            return procedure;
        }

        private async Task InsertConsumablesProcedure(Procedure procedure)
        {
            foreach (var consumable in procedure.Consumables)
            {
                var consumableFound = await _procedureContext.Consumables.AsNoTracking().MinAsync(p => p.Id == consumable.Id);
                _procedureContext.Entry(consumable).CurrentValues.SetValues(consumableFound);
            }
        }

        public async Task<Procedure> Update(Procedure procedure)
        {
            var procedureUpdate = await _procedureContext.Procedures.Include(p => p.Consumables).SingleOrDefaultAsync(p => p.Id == procedure.Id);

            if (procedureUpdate == null)
                return null;

            _procedureContext.Entry(procedureUpdate).CurrentValues.SetValues(procedure);

            await UpdateProcedureConsumables(procedure, procedureUpdate);

            _procedureContext.Procedures.Update(procedureUpdate);

            await _procedureContext.SaveChangesAsync();
            return procedureUpdate;
        }

        private async Task UpdateProcedureConsumables(Procedure procedure, Procedure procedureUpdate)
        {
            foreach (var consumable in procedure.Consumables)
            {
                var consumableFound = await _procedureContext.Consumables.FindAsync(consumable.Id);
                procedureUpdate.Consumables.Append(consumableFound);
                
            }
        }

        public async Task<Procedure> Remove(Procedure procedure)
        {
            //_procedureContext?.Procedures.Remove(procedure);
            await _procedureContext.SaveChangesAsync();
            return procedure;
        }
    }
}
