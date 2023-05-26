using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int? id);

        Task<Customer> Create(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<Customer> Remove(Customer customer);
    }
}
