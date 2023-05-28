using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Consumables.Query
{
    public class GetConsumablesQuery : IRequest<IEnumerable<Consumable>>
    {
    }
}
