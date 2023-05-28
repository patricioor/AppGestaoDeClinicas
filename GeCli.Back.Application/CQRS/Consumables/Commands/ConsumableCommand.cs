using MediatR;
using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Application.CQRS.Consumables.Commands
{
    public class ConsumableCommand : IRequest<Consumable>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
