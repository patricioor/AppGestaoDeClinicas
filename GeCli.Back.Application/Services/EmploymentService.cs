using AutoMapper;
using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;

namespace GeCli.Back.Application.Services
{
    public class EmploymentService : IEmploymentService
    {
        private IEmploymentRepository _employmentRepository;
        private readonly IMapper _mapper;
        public EmploymentService(IEmploymentRepository employmentRepository, IMapper mapper)
        {
            _employmentRepository = employmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmploymentDTO>> GetEmploymentsAsync()
        {
            var employment = await _employmentRepository.GetEmploymentsAsync();
            return _mapper.Map<IEnumerable<EmploymentDTO>>(employment);
        }

        public async Task<EmploymentDTO> GetEmploymentByIdAsync(int id)
        {
            var employment = await _employmentRepository.GetEmploymentByIdAsync(id);
            return _mapper.Map<EmploymentDTO>(employment);
        }
        public async Task CreateEmploymentAsync(EmploymentDTO employmentDTO)
        {
            var employment = _mapper.Map<Employment>(employmentDTO);
            await _employmentRepository.Create(employment);
        }

        public async Task UpdateEmploymentAsync(EmploymentDTO employmentDTO)
        {
            var employment = _mapper.Map<Employment>(employmentDTO);
            await _employmentRepository.Update(employment);
        }

        public async Task DeleteEmploymentAsync(int id)
        {
            var employment = _employmentRepository.GetEmploymentByIdAsync(id).Result;
            await _employmentRepository.Remove(employment);
        }
    }
}
