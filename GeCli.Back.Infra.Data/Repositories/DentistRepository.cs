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

        public async Task<ICollection<Dentist>> GetDentistsAsync()
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
                        .AsNoTracking()
                        .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Dentist> InsertDentistAsync(Dentist dentist)
        {
            await InsertDentistSpecialty(dentist);
            await InsertDentistCellphone(dentist);
            await _context.Dentists.AddAsync(dentist);
            await _context.SaveChangesAsync();
            return dentist;
        }

        private async Task InsertDentistSpecialty(Dentist dentist)
        {
            var dentistConsulted = new List<Specialty>();
            foreach (var specialty in dentist.Specialties)
            {
                var specialityConsulted = await _context.Specialtys.FindAsync(specialty.Id);
                dentistConsulted.Add(specialityConsulted);
            }
            dentist.Specialties = dentistConsulted;
        }

        private async Task InsertDentistCellphone(Dentist dentist)
        {
            var dentistConsulted = new List<DentistCellphone>();
            foreach (var cellphone in dentist.Cellphones)
            {
                var cellphoneConsulted = await _context.DentistsCellphones.FindAsync(cellphone.DentistId, cellphone.Number);
                if (cellphoneConsulted == null)
                    dentistConsulted.Add(cellphone);
            }
            dentist.Cellphones = dentistConsulted;

        }

        public async Task<Dentist> UpdateDentistAsync(Dentist dentist)
        {
            var dentistFound = await _context.Dentists
                                    .Include(p => p.Specialties)
                                    .Include(p => p.Cellphones)
                                    .Include(p => p.Address)
                                    .SingleOrDefaultAsync(p => p.Id == dentist.Id);

            if (dentistFound == null)
                return null;

            _context.Entry(dentistFound).CurrentValues.SetValues(dentist);
            dentistFound.CreationDate = dentist.CreationDate;

            await UpdateDentistCellphone(dentist, dentistFound);
            await UpdateDentistSpecialty(dentist, dentistFound);

            await _context.SaveChangesAsync();
            return dentistFound;
        }

        private async Task UpdateDentistSpecialty(Dentist dentist, Dentist dentistFound)
        {
            foreach (var specialty in dentist.Specialties)
            {
                var specialtyFound = await _context.Specialtys.FindAsync(specialty.Id);
                if(specialtyFound == null)
                    dentistFound.Specialties.Add(specialtyFound);
            }
        }
        private async Task UpdateDentistCellphone(Dentist dentist, Dentist dentistFound)
        {
            foreach (var cellphone in dentist.Cellphones)
            {
                var cellphoneFound = await _context.DentistsCellphones.FindAsync(cellphone.DentistId, cellphone.Number);
                if (cellphoneFound == null)
                    dentistFound.Cellphones.Add(cellphone);
            }
        }

        public async Task DeleteDentistAsync(int id)
        {
            var dentistFound = await _context.Dentists.FindAsync(id);
            _context.Dentists.Remove(dentistFound);
            await _context.SaveChangesAsync();
        }
    }
}
