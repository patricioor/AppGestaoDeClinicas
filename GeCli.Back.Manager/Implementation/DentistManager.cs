using AutoMapper;
using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back.Manager.Implementation
{
    public class DentistManager : IDentistManager
    {
        private readonly IDentistRepository _dentistRepository;
        private readonly IMapper _mapper;

        public DentistManager(IDentistRepository dentistRepository, IMapper mapper)
        {
            _dentistRepository = dentistRepository;
            _mapper = mapper;
        }

        public Task DeleteDentistAsync(int id)
        {
            return _dentistRepository.DeleteDentistAsync(id);
        }

        public async Task<Dentist> GetDentistByIdAsync(int id)
        {
            return await _dentistRepository.GetDentistByIdAsync(id);
        }

        public async Task<IEnumerable<Dentist>> GetDentistsAsync()
        {
            return await _dentistRepository.GetDentistsAsync();
        }

        public async Task<Dentist> InsertDentistAsync(NewDentist newDentist)
        {
            var dentist = _mapper.Map<Dentist>(newDentist);
            return await _dentistRepository.InsertDentistAsync(dentist);
        }

        public async Task<Dentist> UpdateDentistAsync(UpdateDentist updateDentist)
        {
            var dentistFound = _mapper.Map<Dentist>(updateDentist);
            return await _dentistRepository.InsertDentistAsync(dentistFound);
        }
    }
}
