using GeCli.Back.Application.CQRS.Consumables.Query;
using GeCli.Back.Application.CQRS.Customers.Query;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Customers.Handler
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
    {
        private ICustomerRepository _customerRepository;
        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomersAsync();
        }
    }
}
