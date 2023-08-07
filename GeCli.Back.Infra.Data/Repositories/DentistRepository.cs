using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class DentistRepository : IDentistRepository
    {
        readonly ApplicationDbContext _context;
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
            var dentistSpecialties = new List<Specialty>();
            foreach (var specialty in dentist.Specialties)
            {
                var specialityConsulted = await _context.Specialtys
                    .FindAsync(specialty.Id);
                dentistSpecialties.Add(specialityConsulted);
            }
            dentist.Specialties = dentistSpecialties;
        }

        private async Task InsertDentistCellphone(Dentist dentist)
        {
            var dentistConsulted = new List<DentistCellphone>();
            foreach (var cellphone in dentist.Cellphones)
            {
                var cellphoneConsulted = await _context.DentistsCellphones
                    .FindAsync(cellphone.DentistId, cellphone.Number);
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
                                    .FirstOrDefaultAsync(p => p.Id == dentist.Id);

            if (dentistFound == null)
                return null;

            _context.Entry(dentistFound).CurrentValues.SetValues(dentist);
            dentistFound.CreationDate = dentist.CreationDate;
            dentistFound.Address = dentist.Address;
            dentistFound.Cellphones = dentist.Cellphones;

            await UpdateDentistCellphone(dentist, dentistFound);
            await UpdateDentistSpecialty(dentist, dentistFound);

            await _context.SaveChangesAsync();
            return dentistFound;
        }

        private async Task UpdateDentistSpecialty(Dentist dentist, Dentist dentistFound)
        {
            var dentistSpec = new List<Specialty>();
            foreach (var specialty in dentist.Specialties)
            {
                var specialtyFound = await _context.Specialtys.FindAsync(specialty.Id);
                if (specialtyFound != null)
                    dentistSpec.Add(specialtyFound);
            }
            dentistFound.Specialties = dentistSpec;
        }
        private async Task UpdateDentistCellphone(Dentist dentist, Dentist dentistFound)
        {
            dentistFound.Cellphones.Clear();
            foreach (var cellphone in dentist.Cellphones)
            {
                var cellphoneFound = await _context.DentistsCellphones.FindAsync(cellphone.DentistId, cellphone.Number);
                if (cellphoneFound == null)
                    dentistFound.Cellphones.Add(cellphone);
            }
        }

        public async Task<Dentist> DeleteDentistAsync(int id)
        {
            var dentistFound = await _context.Dentists.FindAsync(id);

            if (dentistFound == null) return null;

            var dentistRemoved = _context.Dentists.Remove(dentistFound);
            await _context.SaveChangesAsync();
            return dentistRemoved.Entity;
        }
    }
}
