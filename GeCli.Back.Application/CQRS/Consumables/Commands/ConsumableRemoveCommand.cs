using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Consumables.Commands
{
    public class ConsumableRemoveCommand : IRequest<Consumable>
    {
        public int Id { get; set; }

        public ConsumableRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
