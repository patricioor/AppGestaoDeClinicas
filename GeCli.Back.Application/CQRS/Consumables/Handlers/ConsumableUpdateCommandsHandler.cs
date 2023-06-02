using GeCli.Back.Application.CQRS.Consumables.Commands;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Consumables.Handlers
{
    public class ConsumableUpdateCommandsHandler : IRequestHandler<ConsumableUpdateCommand, Consumable>
    {
        private IConsumableRepository _consumableRepository;
        public ConsumableUpdateCommandsHandler(IConsumableRepository consumableRepository)
        {
            _consumableRepository = consumableRepository;
        }
        public async Task<Consumable> Handle(ConsumableUpdateCommand request, CancellationToken cancellationToken)
        {
            var consumable = await _consumableRepository.GetConsumableByIdAsync(request.Id);

            if (consumable == null)
            {
                throw new ArgumentNullException("Error could not be found");
            }
            else
            {
                consumable.Update(request.Name, request.Stock, request.Price, request.CategoryId);
                return await _consumableRepository.Update(consumable);
            }
        }
    }
}
