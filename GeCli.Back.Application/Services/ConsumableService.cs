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
        public async Task<IEnumerable<ConsumableDTO>> GetConsumablesAsync()
        {
            var consumable = await _consumableRepository.GetConsumablesAsync();
            return _mapper.Map<IEnumerable<ConsumableDTO>>(consumable);
        }

        public async Task<ConsumableDTO> GetConsumableByIdAsync(int id)
        {
            var consumable = await _consumableRepository.GetConsumableByIdAsync(id);
            return _mapper.Map<ConsumableDTO>(consumable);
        }

        public async Task CreateConsumableAsync(ConsumableDTO consumableDTO)
        {
            var consumable = _mapper.Map<Consumable>(consumableDTO);
            await _consumableRepository.Create(consumable);
        }

        public async Task UpdateConsumableAsync(ConsumableDTO consumableDTO)
        {
            var consumable = _mapper.Map<Consumable>(consumableDTO);
            await _consumableRepository.Update(consumable);
        }
        public async Task DeleteConsumableAsync(int id)
        {
            var consumable = _consumableRepository.GetConsumableByIdAsync(id).Result;
            await _consumableRepository.Delete(consumable);
        }
    }
}
