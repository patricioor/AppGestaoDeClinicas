using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetCustomersAsync();
        Task <CustomerDTO> GetCustomerByIdAsync(int id);

        Task CreateCustomerAsync(CustomerDTO customerDTO);
        Task UpdateCustomerAsync(CustomerDTO customerDTO);
        Task DeleteCustomerAsync(int id);
    }
}
