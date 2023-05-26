using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        ApplicationDbContext _customerContext;
        public CustomerRepository(ApplicationDbContext context)
        {
            _customerContext = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int? id)
        {
            return await _customerContext.Customers.FindAsync(id);
        }

       public async Task<Customer> Create(Customer customer)
        {
            _customerContext.Customers.Add(customer);
            await _customerContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _customerContext.Customers.Update(customer);
            await _customerContext.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> Remove(Customer customer)
        {
            _customerContext.Customers.Remove(customer);
            await _customerContext.SaveChangesAsync();
            return customer;
        }
    }
}
