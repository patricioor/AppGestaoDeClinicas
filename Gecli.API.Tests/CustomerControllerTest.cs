using FluentAssertions;
using GeCli.Back.API.Controllers;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace Gecli.API.Tests
{
    public class CustomerControllerTest
    {
        readonly ICustomerManager _manager;
        readonly CustomerController _controller;
        public CustomerControllerTest()
        {
            _manager = Substitute.For<ICustomerManager>();
            _controller = new CustomerController(_manager);
        }
        [Fact]
        public async Task Get_Ok()
        {
            _manager.GetCustomersAsync().Returns(new List<CustomerView> {new CustomerView { Name = "Bla" } });
            var resultado = (ObjectResult)await _controller.Get();
            resultado.Should().Be(StatusCodes.Status200OK);
        }
    }
}