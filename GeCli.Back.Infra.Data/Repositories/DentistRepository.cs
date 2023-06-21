using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class DentistRepository : IDentistRepository
    {
        ApplicationDbContext _context;
        public DentistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dentist>> GetDentistsAsync()
        {
            return await _context.Dentists
                        .Include(p => p.Address)
                        .Include(p => p.Cellphones)
                        .Include(p => p.Specialties)
                        .AsNoTracking().ToListAsync();
        }

        public async Task<Dentist> GetDentistByIdAsync(int id)
        {
            return await _context.Dentists
                        .Include(p => p.Address)
                        .Include(p => p.Cellphones)
                        .Include(p => p.Specialties)
                        .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Dentist> InsertDentistAsync(Dentist dentist)
        {
            await _context.Dentists.AddAsync(dentist);
            await _context.SaveChangesAsync();
            return dentist;
        }

        public async Task<Dentist> UpdateDentistAsync(Dentist dentist)
        {
            var dentistFound = await _context.Dentists.FindAsync(dentist.Id);
            if (dentistFound == null)
                return null;

            _context.Entry(dentistFound).CurrentValues.SetValues(dentist);

            await _context.SaveChangesAsync();
            return dentistFound;
        }

        public async Task DeleteDentistAsync(int id)
        {
            var dentistFound = await _context.Dentists.FindAsync(id);
            _context.Dentists.Remove(dentistFound);
            await _context.SaveChangesAsync();
        }

    }
}
