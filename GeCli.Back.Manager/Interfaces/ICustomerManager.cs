using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Interfaces
{
    public interface ICustomerManager
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);

        Task<CustomerView> InsertCustomerAsync(NewCustomer newCustomer);
        Task<CustomerView> UpdateCustomerAsync(UpdateCustomer updateCustomer);
        Task DeleteCustomerAsync(int id);
    }
}
