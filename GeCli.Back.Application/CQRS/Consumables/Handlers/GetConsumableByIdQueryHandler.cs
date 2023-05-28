using GeCli.Back.Application.CQRS.Consumables.Query;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Consumables.Handlers
{
    public class GetConsumableByIdQueryHandler : IRequestHandler<GetConsumableByIdQuery, Consumable>
    {
        private readonly IConsumableRepository _consumableRepository;
        public GetConsumableByIdQueryHandler(IConsumableRepository consumableRepository)
        {
            _consumableRepository = consumableRepository;
        }
        public async Task<Consumable> Handle(GetConsumableByIdQuery request, CancellationToken cancellationToken)
        {
            return await _consumableRepository.GetConsumableById(request.Id);
        }
    }
}
