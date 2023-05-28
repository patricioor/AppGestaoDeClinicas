using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetCustomers();
        Task <CustomerDTO> GetCustomerById (int? id);

        Task Create(CustomerDTO customerDTO);
        Task Update(CustomerDTO customerDTO);
        Task Delete(int? id);
    }
}
