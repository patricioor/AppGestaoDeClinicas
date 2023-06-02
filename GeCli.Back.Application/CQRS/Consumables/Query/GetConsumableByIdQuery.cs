using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Consumables.Query
{
    public class GetConsumableByIdQuery : IRequest<Consumable>
    {
        public int Id { get; set; }

        public GetConsumableByIdQuery(int id)
        {
            Id = id;
        }
    }
}
