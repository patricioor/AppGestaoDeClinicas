using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class DentistRepository : IDentistRepository
    {
        ApplicationDbContext _dentistContext;
        public DentistRepository(ApplicationDbContext context)
        {
            _dentistContext = context;
        }

        public async Task<IEnumerable<Dentist>> GetDentistsAsync()
        {
            return await _dentistContext.Dentists.AsNoTracking().ToListAsync();
        }

        public async Task<Dentist> GetDentistByIdAsync(int id)
        {
            return await _dentistContext.Dentists.FindAsync(id);
        }

        public async Task<Dentist> Create(Dentist dentist)
        {
            _dentistContext.Dentists.Add(dentist);
            await _dentistContext.SaveChangesAsync();
            return dentist;
        }

        public async Task<Dentist> Update(Dentist dentist)
        {
            _dentistContext.Dentists.Update(dentist);
            await _dentistContext.SaveChangesAsync();
            return dentist;
        }

        public async Task<Dentist> Remove(Dentist dentist)
        {
            _dentistContext.Dentists.Remove(dentist);
            await _dentistContext.SaveChangesAsync();
            return dentist;
        }

    }
}
