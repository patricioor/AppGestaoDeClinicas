using GeCli.Back.Application.CQRS.Consumables.Commands;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Consumables.Handlers
{
    public class ConsumableCreateCommandHandler : IRequestHandler<ConsumableCreateCommand, Consumable>
    {
        private IConsumableRepository _consumableRepository;
        public ConsumableCreateCommandHandler(IConsumableRepository consumableRepository)
        {
            _consumableRepository = consumableRepository;
        }
        public async Task<Consumable> Handle(ConsumableCreateCommand request, CancellationToken cancellationToken)
        {
            var consumable = new Consumable(request.Name, request.Stock, request.Price);

            if (consumable == null)
            {
                throw new ArgumentNullException("Error creating entity");
            }
            else
            {
                consumable.CategoryId = request.CategoryId;
                return await _consumableRepository.Create(consumable);
            }
        }
    }
}
