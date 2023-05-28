using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Customers.Query
{
    public class GetCustomersQuery : IRequest<IEnumerable<Customer>>
    {
    }
}
