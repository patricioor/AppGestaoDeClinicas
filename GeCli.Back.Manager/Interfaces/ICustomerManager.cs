using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Interfaces
{
    public interface ICustomerManager
    {
        Task<ICollection<CustomerView>> GetCustomersAsync();
        Task<CustomerView> GetCustomerByIdAsync(int id);
        Task<CustomerView> InsertCustomerAsync(NewCustomer newCustomer);
        Task<CustomerView> UpdateCustomerAsync(UpdateCustomer updateCustomer);
        Task<CustomerView> DeleteCustomerAsync(int id);
    }
}
