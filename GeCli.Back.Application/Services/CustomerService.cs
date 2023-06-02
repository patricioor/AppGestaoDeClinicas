using AutoMapper;
using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;

namespace GeCli.Back.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomersAsync()
        {
            var customer = await _customerRepository.GetCustomersAsync();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customer);
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task CreateCustomerAsync(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.Create(customer);
        }

        public async Task UpdateCustomerAsync(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.Update(customer);
        }
        public async Task DeleteCustomerAsync(int id)
        {
            var customer = _customerRepository.GetCustomerByIdAsync(id).Result;
            await _customerRepository.Remove(customer);

        }
    }
}
