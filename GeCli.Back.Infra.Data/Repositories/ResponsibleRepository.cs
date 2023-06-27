using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class ResponsibleRepository : IResponsibleRepository
    {
        ApplicationDbContext _responsibleContext;
        public ResponsibleRepository(ApplicationDbContext context)
        {
            _responsibleContext = context;
        }

        public async Task<ICollection<Responsible>> GetResponsiblesAsync()
        {
            return await _responsibleContext.Responsibles.AsNoTracking().ToListAsync();
        }

        public async Task<Responsible> GetResponsiblesByIdAsync(int id)
        {
            return await _responsibleContext.Responsibles.FindAsync(id);
        }

        public async Task<Responsible> Create(Responsible responsible)
        {
            _responsibleContext.Responsibles.Add(responsible);
            await _responsibleContext.SaveChangesAsync();
            return responsible;
        }

        public async Task<Responsible> Update(Responsible responsible)
        {
            _responsibleContext.Responsibles.Update(responsible);
            await _responsibleContext.SaveChangesAsync();
            return responsible;
        }

        public async Task<Responsible> Remove(Responsible responsible)
        {
            _responsibleContext.Responsibles.Remove(responsible);
            await _responsibleContext.SaveChangesAsync();
            return responsible;
        }
    }
}
