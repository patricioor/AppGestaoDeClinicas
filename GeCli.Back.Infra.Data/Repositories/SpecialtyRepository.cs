using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        readonly ApplicationDbContext _context;
        public SpecialtyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Exist(int id)
        {
            return _context.Specialtys.Any(p => p.Id == id);
        }
    }
}
