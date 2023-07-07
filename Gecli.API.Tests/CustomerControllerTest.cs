using FluentAssertions;
using GeCli.Back._FakeData.CustomerData;
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
        private readonly CustomerView _customerView;
        private readonly List<CustomerView> _listCustomerView;

        public CustomerControllerTest()
        {
            _manager = Substitute.For<ICustomerManager>();
            _controller = new CustomerController(_manager);

            _listCustomerView = new CustomerViewFake().Generate(1);
            _customerView = new CustomerViewFake().Generate();
        }
        [Fact]
        public async Task Get_Ok()
        {

            var control = new List<CustomerView>();
            _listCustomerView.ForEach(p => control.Add(p.CloneTyped()));
            _manager.GetCustomersAsync().Returns(_listCustomerView);

            var result = (ObjectResult)await _controller.Get();

            await _manager.Received().GetCustomersAsync();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(control);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            _manager.GetCustomersAsync().Returns(new List<CustomerView>());

            var result = (StatusCodeResult)await _controller.Get();

            await _manager.Received().GetCustomersAsync();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
        [Fact]
        public async Task GetById_Ok()
        {
            _manager.GetCustomerByIdAsync(Arg.Any<int>()).Returns(_customerView.CloneTyped());

            var result = (ObjectResult)await _controller.GetById(_customerView.Id);

            await _manager.Received().GetCustomerByIdAsync(Arg.Any<int>());
            result.Value.Should().BeEquivalentTo(_customerView);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
        [Fact]
        public async Task GetById_NotFound()
        {
            _manager.GetCustomerByIdAsync(Arg.Any<int>()).Returns(new CustomerView());

            var result = (StatusCodeResult) await _controller.GetById(100);

            await _manager.Received().GetCustomerByIdAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}