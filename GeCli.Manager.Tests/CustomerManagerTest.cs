using AutoMapper;
using GeCli.Back._FakeData.CustomerData;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Customer;
using NSubstitute;

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
    }
}
