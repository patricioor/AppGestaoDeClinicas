using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Customers.Command
{
    public class CustomerRemoveCommand : IRequest<Customer>
    {
        public int Id { get; set; }
        public CustomerRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
