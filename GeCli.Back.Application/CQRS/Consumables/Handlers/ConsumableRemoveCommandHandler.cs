using GeCli.Back.Application.CQRS.Consumables.Commands;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Consumables.Handlers
{
    public class ConsumableRemoveCommandHandler : IRequestHandler<ConsumableRemoveCommand, Consumable>
    {
        private IConsumableRepository _consumableRepository;
        public ConsumableRemoveCommandHandler(IConsumableRepository consumableRepository)
        {
            _consumableRepository = consumableRepository;
        }
        public async Task<Consumable> Handle(ConsumableRemoveCommand request, CancellationToken cancellationToken)
        {
            var consumable = await _consumableRepository.GetConsumableByIdAsync(request.Id);

            if (consumable == null)
            {
                throw new ArgumentNullException("Error could not be found");
            }
            else
            {
                var result = await _consumableRepository.Delete(consumable);
                return result;
            }
        }
    }
}
