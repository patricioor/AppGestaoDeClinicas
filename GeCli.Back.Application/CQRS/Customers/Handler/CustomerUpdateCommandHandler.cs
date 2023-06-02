using GeCli.Back.Application.CQRS.Customers.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Customers.Handler
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand, Customer>
    {
        private ICustomerRepository _customerRepository;

        public CustomerUpdateCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        async Task<Customer> IRequestHandler<CustomerUpdateCommand, Customer>.Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);
            if (customer == null)
            {
                throw new ArgumentNullException("Error could not be found.");
            }
            else
            {
                customer.Update(request.Name, request.Address, request.Cellphone, request.Birth, request.ResponsibleId);

                return await _customerRepository.Update(customer);

            }
        }
    }
}
