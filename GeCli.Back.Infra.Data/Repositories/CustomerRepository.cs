using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories;
public class CustomerRepository : ICustomerRepository
{
    readonly ApplicationDbContext _customerContext;
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
        await InsertCustomerCellphone(customer);
        await _customerContext.AddAsync(customer);
        await _customerContext.SaveChangesAsync();
        return customer;
    }

    private async Task InsertCustomerCellphone(Customer customer)
    {
        var customerConsulted = new List<CustomerCellphone>();
        foreach (var cellphone in customer.Cellphones)
        {
            var cellphoneConsulted = await _customerContext.CustomersCellphones
                .FindAsync(cellphone.CustomerId, cellphone.Number);
            if (cellphoneConsulted == null)
                customerConsulted.Add(cellphone);
        }
        customer.Cellphones = customerConsulted;
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        var customerInsert = await _customerContext.Customers
                            .Include(p => p.Address)
                            .Include(p => p.Cellphones)
                            .FirstOrDefaultAsync(p => p.Id == customer.Id);

        if (customerInsert == null)
            return null;

        _customerContext.Entry(customerInsert).CurrentValues.SetValues(customer);
        customerInsert.CreationDate = customer.CreationDate;
        customerInsert.Address = customer.Address;
        customerInsert.Cellphones = customer.Cellphones;

        await UpdateCustomerCellphone(customer, customerInsert);

        await _customerContext.SaveChangesAsync();
        return customerInsert;
    }

    private async Task UpdateCustomerCellphone(Customer customer, Customer customerFound)
    {
        var customerCell = new List<CustomerCellphone>();
        foreach (var cellphone in customer.Cellphones)
        {
            var cellphoneFound = await _customerContext.CustomersCellphones
                .FindAsync(cellphone.CustomerId, cellphone.Number);
            if (cellphoneFound == null)
                customerCell.Add(cellphone);
        }
        if (customerCell.Count != customerFound.Cellphones.Count())
            customerFound.Cellphones = customerCell;
    }

    public async Task<Customer> DeleteCustomerAsync(int id)
    {
        var customerFound = await _customerContext.Customers.FindAsync(id);

        if(customerFound == null) return null;
        
        var customerRemoved = _customerContext.Customers.Remove(customerFound);
        await _customerContext.SaveChangesAsync();
        return customerRemoved.Entity;
    }
}
