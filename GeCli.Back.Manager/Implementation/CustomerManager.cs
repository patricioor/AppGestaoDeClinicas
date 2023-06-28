using AutoMapper;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetCustomersAsync();
        }

        public async Task<CustomerView> InsertCustomerAsync(NewCustomer newCustomer)
        {
            var customer = _mapper.Map<Customer>(newCustomer);
            return _mapper.Map<CustomerView>(await _customerRepository.InsertCustomerAsync(customer));
        }
        public async Task<CustomerView> UpdateCustomerAsync(UpdateCustomer updateCustomer)
        {
            var customer = _mapper.Map<Customer>(updateCustomer);
            return _mapper.Map<CustomerView>(await _customerRepository.UpdateCustomerAsync(customer));
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }
    }
}
