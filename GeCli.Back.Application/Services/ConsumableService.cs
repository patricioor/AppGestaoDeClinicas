using AutoMapper;
using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;

namespace GeCli.Back.Application.Services
{
    public class ConsumableService : IConsumableService
    {
        private IConsumableRepository _consumableRepository { get; set; }
        private readonly IMapper _mapper;

        public ConsumableService(IConsumableRepository consumableRepository, IMapper mapper)
        {
            _consumableRepository = consumableRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ConsumableDTO>> GetConsumables()
        {
            var consumable = await _consumableRepository.GetConsumables();
            return _mapper.Map<IEnumerable<ConsumableDTO>>(consumable);
        }

        public async Task<ConsumableDTO> GetConsumableById(int? id)
        {
            var consumable = await _consumableRepository.GetConsumableById(id);
            return _mapper.Map<ConsumableDTO>(consumable);
        }

        public async Task Create(ConsumableDTO consumableDTO)
        {
            var consumable = _mapper.Map<Consumable>(consumableDTO);
            await _consumableRepository.Create(consumable);
        }

        public async Task Update(ConsumableDTO consumableDTO)
        {
            var consumable = _mapper.Map<Consumable>(consumableDTO);
            await _consumableRepository.Update(consumable);
        }
        public async Task Delete(int? id)
        {
            var consumable = _consumableRepository.GetConsumableById(id).Result;
            await _consumableRepository.Delete(consumable);
        }
    }
}
