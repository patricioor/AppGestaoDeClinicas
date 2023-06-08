using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

       public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var CustomerFound = await _context.Customers.FindAsync(customer.Id);
            if (CustomerFound == null)
                return null;

            _context.Entry(CustomerFound).CurrentValues.SetValues(customer);
            await _context.SaveChangesAsync();
            return CustomerFound;
        }
        public async Task DeleteCustomerAsync(int id)
        {
            var CustomerFound = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(CustomerFound);
            await _context.SaveChangesAsync();
        }
    }
}
