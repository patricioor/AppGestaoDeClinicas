using FluentAssertions;
using GeCli.Back._FakeData.CellphoneData;
using GeCli.Back._FakeData.CustomerData;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using GeCli.Back.Infra.Data.Repositories;
using GeCli.Back.Manager.Implementation;
using GeCli.Back.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Xunit;

namespace GeCli.Repository.Tests.Repository
{
    public class CustomerRepositoryTest :IDisposable
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

        private async Task<List<Customer>> RecordInsert()
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
            var record = await RecordInsert();
            var returnRegister = await _customerRepository.GetCustomersAsync();

            returnRegister.Should().HaveCount(record.Count);
            returnRegister.First().Address.Should().NotBeNull();
            returnRegister.First().Cellphones.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCustomersAsync_Void()
        {
            var returnResult = await _customerRepository.GetCustomersAsync();
            returnResult.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetCustomerById_Found()
        {
            var records = await RecordInsert();
            var returnResult = await _customerRepository.GetCustomerByIdAsync(records.First().Id);
            returnResult.Should().BeEquivalentTo(records.First());
        }

        [Fact]
        public async Task GetCustomerById_NotFound()
        {
            var returnResult = await _customerRepository.GetCustomerByIdAsync(1);
            returnResult.Should().BeNull();
        }

        [Fact]
        public async Task InsertCustomer_Ok()
        {
            var returnResult = await _customerRepository.InsertCustomerAsync(_customer);
            returnResult.Should().BeEquivalentTo(_customer);
        }

        [Fact]
        public async Task UpdateCustomer_Ok()
        {
            var register = await RecordInsert();
            var alterCustomer = _customerFaker.Generate();
            alterCustomer.Id = register.First().Id;
            var returnResult = await _customerRepository.UpdateCustomerAsync(alterCustomer);
            returnResult.Should().BeEquivalentTo(alterCustomer);      
        }

        [Fact]
        public async Task UpdateCustomer_AddCellphone()
        {
            var register = await RecordInsert();
            var alterCustomer = register.First();
            alterCustomer.Cellphones.Add(new CustomerCellphonesFake(alterCustomer.Id).Generate());
            var returnResult = await _customerRepository.UpdateCustomerAsync(alterCustomer);
            returnResult.Should().BeEquivalentTo(alterCustomer);
        }

        [Fact]
        public async Task UpdateCustomer_RemoveCellphone()
        {
            var register = await RecordInsert();
            var alterCustomer = register.First();
            alterCustomer.Cellphones.Remove(alterCustomer.Cellphones.First());
            var returnResult = await _customerRepository.UpdateCustomerAsync(alterCustomer);
            returnResult.Should().BeEquivalentTo(alterCustomer);
        }

        [Fact]
        public async Task UpdateCustomer_RemoveAllCellphones()
        {
            var register = await RecordInsert();
            var alterCustomer = register.First();
            alterCustomer.Cellphones.Clear();
            var returnResult = await _customerRepository.UpdateCustomerAsync(alterCustomer);
            returnResult.Should().BeEquivalentTo(alterCustomer);
        }

        [Fact]
        public async Task UpdateCustomer_NotFound()
        {
            var returnResult = await _customerRepository.UpdateCustomerAsync(_customer);
            returnResult.Should().BeNull();
        }

        [Fact]
        public async Task DeleteCustomer_Ok()
        {
            var register = await RecordInsert();

            var returnResult = await _customerRepository.DeleteCustomerAsync(register.First().Id);
            returnResult.Should().BeEquivalentTo(register.First());
        }

        [Fact]
        public async Task DeleteCustomer_NotFound()
        {
            var returnResult = await _customerRepository.DeleteCustomerAsync(1);
            returnResult.Should().BeNull();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
