using AutoMapper;
using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;

namespace GeCli.Back.Application.Services
{
    public class DentistService : IDentistService
    {
        private IDentistRepository _dentistRepository;
        private readonly IMapper _mapper;
        public DentistService(IDentistRepository dentistRepository, IMapper mapper)
        {
            _dentistRepository = dentistRepository;
            _mapper = mapper;
        }
        public async Task CreateDentistAsync(DentistDTO dentistDTO)
        {
            var dentist = _mapper.Map<Dentist>(dentistDTO);
            await _dentistRepository.Create(dentist);
        }

        public async Task DeleteDentistAsync(int id)
        {
            var dentist = _dentistRepository.GetDentistByIdAsync(id).Result;
            await _dentistRepository.Remove(dentist);
        }

        public async Task<DentistDTO> GetDentistByIdAsync(int id)
        {
            var dentist = await _dentistRepository.GetDentistByIdAsync(id);
            return _mapper.Map<DentistDTO>(dentist);
        }

        public async Task<IEnumerable<DentistDTO>> GetDentistsAsync()
        {
            var dentist = await _dentistRepository.GetDentistsAsync();
            return _mapper.Map<IEnumerable<DentistDTO>>(dentist);
        }

        public async Task UpdateDentistAsync(DentistDTO dentistDTO)
        {
            var dentist = _mapper.Map<Dentist>(dentistDTO);
            await _dentistRepository.Update(dentist);
        }
    }
}
