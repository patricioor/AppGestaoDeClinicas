using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Customers.Query
{
    internal class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int? Id { get; set; }
        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
