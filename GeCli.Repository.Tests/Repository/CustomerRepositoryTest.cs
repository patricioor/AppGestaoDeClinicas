using GeCli.Back._FakeData.CustomerData;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using GeCli.Back.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Xunit;

namespace GeCli.Repository.Tests.Repository
{
    public class CustomerRepositoryTest
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ApplicationDbContext _context;
        private readonly Customer _customer;
        private CustomerFake _customerFaker;
        public CustomerRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            _context = new ApplicationDbContext(optionsBuilder.Options);
            _customerRepository = new CustomerRepository(_context);

            _customerFaker = new CustomerFake();
            _customer = _customerFaker.Generate();
        }

        private async Task<List<Customer>> RegisterInsert()
        {
            var customers = _customerFaker.Generate(100);

            foreach (var customer in customers)
            {
                customer.Id = 0;
                await _context.Customers.AddAsync(customer);
            }
            await _context.SaveChangesAsync();
            return customers;
        }

        [Fact]
        public async Task GetCustomersAsync_WithReturn()
        {
            var register = await RegisterInsert();
            var returnRegister = await _customerRepository.GetCustomersAsync();

            returnRegister.Should().HaveCount(register.Count);
            returnRegister.First().Address.Should().NotBeNull();
            returnRegister.First().Cellphones.Should().NotBeNull();
        }

        internal void Dispose() => _context.Database.EnsureDeleted();
        
    }
}
