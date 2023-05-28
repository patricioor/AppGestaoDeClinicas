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
            var customer = await _customerRepository.GetCustomerById(request.Id);
            if (customer == null)
            {
                throw new ArgumentNullException("Error could not be found.");
            }
            else
            {
                if (request.Responsible)
                {
                    customer.Update(request.Name, request.Address, request.Cellphone, request.Birth, request.Responsible, request.ResponsibleId);
                }
                else
                {
                    customer.Update(request.Name, request.Address, request.Cellphone, request.Birth, request.Responsible);
                }
                return await _customerRepository.Update(customer);

            }
        }
    }
}
