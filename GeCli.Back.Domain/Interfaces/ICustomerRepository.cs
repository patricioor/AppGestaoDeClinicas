﻿using GeCli.Back.Domain.Entities.Customers;

namespace GeCli.Back.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> InsertCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<Customer> DeleteCustomerAsync(int id);
    }
}
