using GeCli.Back.Application.CQRS.Consumables.Query;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Consumables.Handlers
{
    public class GetConsumablesQueryHandler : IRequestHandler<GetConsumablesQuery, IEnumerable<Consumable>>
    {
        private readonly IConsumableRepository _consumableRepository;
        public GetConsumablesQueryHandler(IConsumableRepository consumableRepository)
        {
            _consumableRepository = consumableRepository;
        }
        public async Task<IEnumerable<Consumable>> Handle(GetConsumablesQuery request, CancellationToken cancellationToken)
        {
            return await _consumableRepository.GetConsumablesAsync();
        }
    }
}
