using AutoMapper;
using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;

namespace GeCli.Back.Application.Services
{
    public class ResponsibleService : IResponsibleService
    {
        private IResponsibleRepository _responsibleRepository;
        private readonly IMapper _mapper;
        public ResponsibleService(IResponsibleRepository responsibleRepository, IMapper mapper)
        {
            _responsibleRepository = responsibleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResponsibleDTO>> GetResponsibleAsync()
        {
            var responsible = await _responsibleRepository.GetResponsiblesAsync();
            return _mapper.Map<IEnumerable<ResponsibleDTO>>(responsible);
        }

        public async Task<ResponsibleDTO> GetResponsibleByIdAsync(int id)
        {
            var responsible = await _responsibleRepository.GetResponsiblesByIdAsync(id);
            return _mapper.Map<ResponsibleDTO>(responsible);
        }

        public async Task CreateResponsibleAsync(ResponsibleDTO responsibleDTO)
        {
            var responsible = _mapper.Map<Responsible>(responsibleDTO);
            await _responsibleRepository.Create(responsible);
        }

        public async Task UpdateResponsibleAsync(ResponsibleDTO responsibleDTO)
        {
            var responsible = _mapper.Map<Responsible>(responsibleDTO);
            await _responsibleRepository.Update(responsible);
        }

        public async Task DeleteResponsibleAsync(int id)
        {
            var responsible = _responsibleRepository.GetResponsiblesByIdAsync(id).Result;
            await _responsibleRepository.Remove(responsible);
        }
    }
}
