using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Customers.Command
{
    public class CustomerCommand : IRequest<Customer>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public string Birth { get; set; }
        public bool Responsible { get; set; }
        public int ResponsibleId { get; set; }
    }
}
