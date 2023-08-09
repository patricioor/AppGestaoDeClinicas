using FluentAssertions;
using GeCli.Back._FakeData.SupplierData;
using GeCli.Back.API.Controllers;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Suppliers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace GeCli.API.Tests;

public class SupplierControllerTest
{
    readonly ISupplierManager _supplierManager;
    readonly SupplierController _controller;
    readonly SupplierView _supplierView;
    readonly NewSupplier _newSupplier;
    readonly List<SupplierView> _listSupplierView;
    public SupplierControllerTest()
    {
        _supplierManager = Substitute.For<ISupplierManager>();
        _controller = new SupplierController(_supplierManager);

        _listSupplierView = new SupplierViewFake().Generate(4);
        _supplierView = new SupplierViewFake().Generate();
        _newSupplier = new NewSupplierFake().Generate();
    }

    [Fact]
    public async Task GetSuppliers_Ok()
    {
        var control = new List<SupplierView>();
        _listSupplierView.ForEach(p => control.Add(p.ClonedTyped()));
        _supplierManager.GetSuppliersAsync().Returns(_listSupplierView);

        var result = (ObjectResult)await _controller.Get();

        await _supplierManager.Received().GetSuppliersAsync();
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetSuppliers_NotFound()
    {
        _supplierManager.GetSuppliersAsync().Returns(new List<SupplierView>());

        var result = (StatusCodeResult)await _controller.Get();

        await _supplierManager.Received().GetSuppliersAsync();
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task GetSupplierById_Ok()
    {
        _supplierManager.GetSupplierByIdAsync(Arg.Any<int>()).Returns(_supplierView.ClonedTyped());

        var result = (ObjectResult)await _controller.GetById(_supplierView.Id);

        await _supplierManager.Received().GetSupplierByIdAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetSupplierById_NotFound()
    {
        _supplierManager.GetSupplierByIdAsync(Arg.Any<int>()).Returns(new SupplierView());

        var result = (StatusCodeResult)await _controller.GetById(1);

        await _supplierManager.Received().GetSupplierByIdAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task InsertSupplier_Ok()
    {
        _supplierManager.InsertSupplierAsync(Arg.Any<NewSupplier>()).Returns(_supplierView.ClonedTyped());

        var result = (ObjectResult)await _controller.Post(_newSupplier);

        await _supplierManager.Received().InsertSupplierAsync(Arg.Any<NewSupplier>());
        result.StatusCode.Should().Be(StatusCodes.Status201Created);
    }

    [Fact]
    public async Task UpdateSupplier_Ok()
    {
        _supplierManager.UpdateSupplierAsync(Arg.Any<UpdateSupplier>()).Returns(_supplierView.ClonedTyped());

        var result = (ObjectResult)await _controller.Put(new UpdateSupplier());

        await _supplierManager.Received().UpdateSupplierAsync(Arg.Any<UpdateSupplier>());
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Value.Should().BeEquivalentTo(_supplierView);
    }

    [Fact]
    public async Task UpdateSupplier_NotFound()
    {
        _supplierManager.UpdateSupplierAsync(Arg.Any<UpdateSupplier>()).ReturnsNull();

        var result = (StatusCodeResult)await _controller.Put(new UpdateSupplier());

        await _supplierManager.Received().UpdateSupplierAsync(Arg.Any<UpdateSupplier>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task DeleteSupplier_NoContent()
    {
        _supplierManager.DeleteSupplierAsync(Arg.Any<int>()).Returns(_supplierView.ClonedTyped());

        var result = (StatusCodeResult)await _controller.Delete(1);

        await _supplierManager.Received().DeleteSupplierAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task DeleteSupplier_NotFound()
    {
        _supplierManager.DeleteSupplierAsync(Arg.Any<int>()).ReturnsNull();

        var result = (StatusCodeResult) await _controller.Delete(1);

        await _supplierManager.Received().DeleteSupplierAsync(Arg.Any<int>());
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}
