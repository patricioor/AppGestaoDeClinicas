using AutoMapper;
using GeCli.Back._FakeData.CustomerData;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Implementation;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Manager.Mappings;
using GeCli.Back.Shared.ModelView.Customer;
using NSubstitute;
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
        _customerManager = new CustomerManager(_customerRepository,_mapper);
        _customerFake = new CustomerFake();
        _newCustomerFake = new NewCustomerFake();

        _customer = _customerFake.Generate();
        _newCustomer = _newCustomerFake.Generate();
        _updateCustomer = _updateCustomerFake.Generate();
    }

    //Corrigir
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
}
