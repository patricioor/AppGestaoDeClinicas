using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Interfaces
{
    public interface ICustomerManager
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);

        Task<Customer> InsertCustomerAsync(NewCustomer newCustomer);
        Task<Customer> UpdateCustomerAsync(UpdateCustomer updateCustomer);
        Task DeleteCustomerAsync(int id);
    }
}
