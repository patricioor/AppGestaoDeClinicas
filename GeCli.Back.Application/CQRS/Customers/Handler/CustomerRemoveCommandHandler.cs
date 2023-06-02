using GeCli.Back.Application.CQRS.Customers.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Customers.Handler
{
    public class CustomerRemoveCommandHandler : IRequestHandler<CustomerRemoveCommand, Customer>
    {
        private ICustomerRepository _customerRepository;

        public CustomerRemoveCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(CustomerRemoveCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);
            if (customer == null)
            {
                throw new ArgumentNullException("Error could not be found.");
            }
            else
            {
                var result = await _customerRepository.Remove(customer);
                return result;
            }
        }
    }
}
