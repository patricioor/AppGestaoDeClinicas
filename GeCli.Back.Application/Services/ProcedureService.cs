using AutoMapper;
using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;

namespace GeCli.Back.Application.Services
{
    public class ProcedureService : IProcedureService
    {
        private IProcedureRepository _procedureRepository;
        private readonly IMapper _mapper;
        public ProcedureService(IProcedureRepository procedureRepository, IMapper mapper)
        {
            _procedureRepository = procedureRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProcedureDTO>> GetProceduresAsync()
        {
            var procedure = await _procedureRepository.GetProceduresAsync();
            return _mapper.Map<IEnumerable<ProcedureDTO>>(procedure);
        }

        public async Task<ProcedureDTO> GetProcedureByIdAsync(int id)
        {
            var procedure = await _procedureRepository.GetProcedureByIdAsync(id);
            return _mapper.Map<ProcedureDTO>(procedure);
        }

        public async Task CreateProcedureAsync(ProcedureDTO procedureDTO)
        {
            var procedure = _mapper.Map<Procedure>(procedureDTO);
            await _procedureRepository.Create(procedure);
        }

        public async Task UpdateProcedureAsync(ProcedureDTO procedureDTO)
        {
            var procedure = _mapper.Map<Procedure>(procedureDTO);
            await _procedureRepository.Update(procedure);
        }
        public async Task DeleteProcedureAsync(int id)
        {
            var procedure = _procedureRepository.GetProcedureByIdAsync(id).Result;
            await _procedureRepository.Remove(procedure);
        }
    }
}
