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

        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            var customer = await _customerRepository.GetCustomers();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customer);
        }

        public async Task<CustomerDTO> GetCustomerById(int? id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task Create(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.Create(customer);
        }

        public async Task Update(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.Update(customer);
        }
        public async Task Delete(int? id)
        {
            var customer = _customerRepository.GetCustomerById(id).Result;
            await _customerRepository.Remove(customer);

        }
    }
}
