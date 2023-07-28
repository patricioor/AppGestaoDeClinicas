using AutoMapper;
using GeCli.Back.Domain.Entities.Consumables;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Consumable;

namespace GeCli.Back.Manager.Implementation;

public class ConsumableManager : IConsumableManager
{
    readonly IConsumableRepository _consumableRepository;
    readonly IMapper _mapper;
    public ConsumableManager(IConsumableRepository consumableRepository, IMapper mapper)
    {
        _consumableRepository = consumableRepository;
        _mapper = mapper;
    }
    public async Task<ConsumableView> GetConsumableByIdAsync(int id)
    {
        return _mapper.Map<ConsumableView>(await _consumableRepository.GetConsumableByIdAsync(id));
    }

    public async Task<ICollection<ConsumableView>> GetConsumablesAsync()
    {
        return _mapper.Map<ICollection<ConsumableView>>(await _consumableRepository.GetConsumablesAsync());
    }

    public async Task<ConsumableView> InsertConsumableAsync(NewConsumable newConsumable)
    {
        var consumable = _mapper.Map<Consumable>(newConsumable);
        return _mapper.Map<ConsumableView>(await _consumableRepository.InsertConsumableAsync(consumable));
    }

    public async Task<ConsumableView> UpdateConsumableAsync(UpdateConsumable updateConsumable)
    {
        var consumable = _mapper.Map<Consumable>(updateConsumable);
        return _mapper.Map<ConsumableView>(await _consumableRepository.UpdateConsumableAsync(consumable));
    }

    public async Task<ConsumableView> DeleteConsumableAsync(int id)
    {
        var removedConsumable = await _consumableRepository.DeleteConsumableAsync(id);
        return _mapper.Map<ConsumableView>(removedConsumable);
    }
}
