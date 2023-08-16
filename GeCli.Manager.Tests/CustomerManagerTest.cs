using AutoMapper;
using FluentAssertions;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Implementation;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Manager.Mappings;
using GeCli.Back.Shared.ModelView.Customer;
using GeCli.FakeData.CustomerData;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace GeCli.Manager.Tests;

public class CustomerManagerTest
{
    readonly ICustomerRepository _customerRepository;
    readonly IMapper _mapper;
    readonly ICustomerManager _customerManager;
    readonly Customer _customer;
    readonly NewCustomer _newCustomer;
    readonly UpdateCustomer _updateCustomer;
    readonly CustomerFake _customerFake;
    readonly NewCustomerFake _newCustomerFake;
    readonly UpdateCustomerFake _updateCustomerFake;

    public CustomerManagerTest()
    {
        _customerRepository = Substitute.For<ICustomerRepository>();
        _mapper = new MapperConfiguration(p => p.AddProfile<CustomerMappingProfile>()).CreateMapper();
        _customerManager = new CustomerManager(_customerRepository, _mapper);
        _customerFake = new CustomerFake();
        _newCustomerFake = new NewCustomerFake();
        _updateCustomerFake = new UpdateCustomerFake();

        _customer = _customerFake.Generate();
        _newCustomer = _newCustomerFake.Generate();
        _updateCustomer = _updateCustomerFake.Generate();
    }

    [Fact]
    public async Task GetCustomers_Ok()
    {
        var listCustomer = _customerFake.Generate(10);
        _customerRepository.GetCustomersAsync().Returns(listCustomer);

        var control = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerView>>(listCustomer);
        var returnResult = await _customerManager.GetCustomersAsync();

        await _customerRepository.Received().GetCustomersAsync();
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task GetCustomer_Void()
    {
        _customerRepository.GetCustomersAsync().Returns(new List<Customer>());

        var returnResult = await _customerManager.GetCustomersAsync();

        await _customerRepository.Received().GetCustomersAsync();
        returnResult.Should().BeEquivalentTo(new List<Customer>());
    }

    [Fact]
    public async Task GetCustomerById_Ok()
    {
        _customerRepository.GetCustomerByIdAsync(Arg.Any<int>()).Returns(_customer);

        var control = _mapper.Map<CustomerView>(_customer);
        var returnResult = await _customerManager.GetCustomerByIdAsync(_customer.Id);

        await _customerRepository.Received().GetCustomerByIdAsync(Arg.Any<int>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task GetCustomerById_NotFound()
    {
        _customerRepository.GetCustomerByIdAsync(Arg.Any<int>()).Returns(new Customer());

        var control = _mapper.Map<CustomerView>(new Customer());
        var returnResult = await _customerManager.GetCustomerByIdAsync(control.Id);

        await _customerRepository.Received().GetCustomerByIdAsync(Arg.Any<int>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task InsertCustomer_Ok()
    {
        _customerRepository.InsertCustomerAsync(Arg.Any<Customer>()).Returns(_customer);

        var control = _mapper.Map<CustomerView>(_customer);
        var returnResult = await _customerManager.InsertCustomerAsync(_newCustomer);

        await _customerRepository.Received().InsertCustomerAsync(Arg.Any<Customer>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task UpdateCustomer_Ok()
    {
        _customerRepository.UpdateCustomerAsync(Arg.Any<Customer>()).Returns(_customer);

        var control = _mapper.Map<CustomerView>(_customer);
        var returnResult = await _customerManager.UpdateCustomerAsync(_updateCustomer);

        await _customerRepository.Received().UpdateCustomerAsync(Arg.Any<Customer>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task UpdateCustomer_NotFound()
    {
        _customerRepository.UpdateCustomerAsync(Arg.Any<Customer>()).ReturnsNull();

        var returnResult = await _customerManager.UpdateCustomerAsync(_updateCustomer);

        await _customerRepository.Received().UpdateCustomerAsync(Arg.Any<Customer>());
        returnResult.Should().BeNull();
    }

    [Fact]
    public async Task DeleteCustomer_Ok()
    {
        _customerRepository.DeleteCustomerAsync(Arg.Any<int>()).Returns(_customer);

        var control = _mapper.Map<CustomerView>(_customer);
        var returnResult = await _customerManager.DeleteCustomerAsync(control.Id);

        await _customerRepository.DeleteCustomerAsync(Arg.Any<int>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task DeleteCustomer_NotFound()
    {
        _customerRepository.DeleteCustomerAsync(Arg.Any<int>()).ReturnsNull();

        var returnResult = await _customerManager.DeleteCustomerAsync(1);

        await _customerRepository.DeleteCustomerAsync(Arg.Any<int>());
        returnResult.Should().BeNull();
    }
}
