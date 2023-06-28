using GeCli.Back.Infra.Data.Context;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        readonly ApplicationDbContext _context;
        public SpecialtyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Specialtys.AnyAsync(p => p.Id == id);
        }
    }
}
