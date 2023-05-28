using GeCli.Back.Application.CQRS.Customers.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Customers.Handler
{
    public class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommand, Customer>
    {
        private ICustomerRepository _customerRepository;
        public CustomerCreateCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name, request.Address, request.Cellphone, request.Birth, request.Responsible);
            if (customer == null)
            {
                throw new ArgumentNullException("Error creating entity");
            }
            else
            {
                if (request.Responsible)
                    customer.ResponsibleId = request.ResponsibleId;
                return await _customerRepository.Create(customer);
            }
        }
    }
}
