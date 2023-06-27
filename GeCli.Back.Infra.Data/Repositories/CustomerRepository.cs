using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        ApplicationDbContext _customerContext;
        public CustomerRepository(ApplicationDbContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<ICollection<Customer>> GetCustomersAsync()
        {
            return await _customerContext.Customers
                .Include(p => p.Address)
                .Include(p => p.Cellphones)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerContext.Customers
               .Include(p => p.Address)
               .Include(p => p.Cellphones)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            await _customerContext.AddAsync(customer);        
            await _customerContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var customerFound = await _customerContext.Customers.FindAsync(customer.Id);
            if (customerFound == null)
                return null;

            _customerContext.Entry(customerFound).CurrentValues.SetValues(customer);

            await _customerContext.SaveChangesAsync();
            return customerFound;
        }
        public async Task DeleteCustomerAsync(int id)
        {
            var customerFound = await _customerContext.Customers.FindAsync(id);
            _customerContext.Customers.Remove(customerFound);
            await _customerContext.SaveChangesAsync();
        }
    }
}
