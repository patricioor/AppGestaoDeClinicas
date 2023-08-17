using AutoMapper;
using FluentAssertions;
using GeCli.Back.Domain.Entities.Suppliers;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Implementation;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Manager.Mappings;
using GeCli.Back.Shared.ModelView.Suppliers;
using GeCli.FakeData.SupplierData;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NSubstitute.Routing.Handlers;
using Xunit;

namespace GeCli.Manager.Tests;

public class SupplierManagerTest
{
    readonly ISupplierRepository _supplierRepository;
    readonly ISupplierManager _supplierManager;
    readonly IMapper _mapper;
    readonly Supplier _supplier;
    readonly NewSupplier _newSupplier;
    readonly UpdateSupplier _updateSupplier;
    readonly SupplierFake _supplierFake;
    readonly NewSupplierFake _newSupplierFake;
    readonly UpdateSupplierFake _updateSupplierFake;

    public SupplierManagerTest()
    {
        _supplierRepository = Substitute.For<ISupplierRepository>();
        _mapper = new MapperConfiguration(p => p.AddProfile<SupplierMappingProfile>()).CreateMapper();

        _supplierManager = new SupplierManager(_supplierRepository, _mapper);
        _supplierFake = new SupplierFake();
        _newSupplierFake = new NewSupplierFake();
        _updateSupplierFake = new UpdateSupplierFake();

        _supplier = _supplierFake.Generate();
        _newSupplier = _newSupplierFake.Generate();
        _updateSupplier = _updateSupplierFake.Generate();
    }

    [Fact]
    public async Task GetSuppliers_Ok()
    {
        var listSuppliers = _supplierFake.Generate(10);
        _supplierRepository.GetSuppliersAsync().Returns(listSuppliers);

        var control = _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierView>>(listSuppliers);
        var returnResult = await _supplierManager.GetSuppliersAsync();

        await _supplierRepository.Received().GetSuppliersAsync();
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task GetSuppliers_Void()
    {
        _supplierRepository.GetSuppliersAsync().Returns(new List<Supplier>());

        var returnResult = await _supplierRepository.GetSuppliersAsync();

        await _supplierRepository.Received().GetSuppliersAsync();
        returnResult.Should().BeEquivalentTo(new List<Supplier>());
    }

    [Fact]
    public async Task GetSupplierById_Ok()
    {
        _supplierRepository.GetSupplierByIdAsync(Arg.Any<int>()).Returns(_supplier);

        var control = _mapper.Map<SupplierView>(_supplier);
        var returnResult = await _supplierManager.GetSupplierByIdAsync(_supplier.Id);

        await _supplierRepository.Received().GetSupplierByIdAsync(Arg.Any<int>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task GetSupplierById_NotFound()
    {
        _supplierRepository.GetSupplierByIdAsync(Arg.Any<int>()).ReturnsNull();

        var returnResult = await _supplierManager.GetSupplierByIdAsync(1);

        await _supplierRepository.Received().GetSupplierByIdAsync(Arg.Any<int>());
        returnResult.Should().BeNull();
    }

    [Fact]
    public async Task InsertSupplier_Ok()
    {
        _supplierRepository.InsertSupplierAsync(Arg.Any<Supplier>()).Returns(_supplier);

        var control = _mapper.Map<SupplierView>(_supplier);
        var returnResult = await _supplierManager.InsertSupplierAsync(_newSupplier);

        await _supplierRepository.Received().InsertSupplierAsync(Arg.Any<Supplier>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task UpdateSupplier_Ok()
    {
        _supplierRepository.UpdateSupplierAsync(Arg.Any<Supplier>()).Returns(_supplier);

        var control = _mapper.Map<SupplierView>(_supplier);
        var returnResult = await _supplierManager.UpdateSupplierAsync(_updateSupplier);

        await _supplierRepository.Received().UpdateSupplierAsync(Arg.Any<Supplier>());
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task UpdateSupplier_NotFound()
    {
        _supplierRepository.UpdateSupplierAsync(Arg.Any<Supplier>()).ReturnsNull();

        var returnResult = await _supplierManager.UpdateSupplierAsync(_updateSupplier);

        await _supplierRepository.Received().UpdateSupplierAsync(Arg.Any<Supplier>());
        returnResult.Should().BeNull();
    }

    [Fact]
    public async Task DeleteSupplier_NoContent()
    {
        _supplierRepository.DeleteSupplierAsync(Arg.Any<int>()).Returns(_supplier);

        var control = _mapper.Map<SupplierView>(_supplier);
        var returnResult = await _supplierManager.DeleteSupplierAsync(_supplier.Id);

        await _supplierRepository.Received().DeleteSupplierAsync(_supplier.Id);
        returnResult.Should().BeEquivalentTo(control);
    }

    [Fact]
    public async Task DeleteSupplier_NotFound()
    {
        _supplierRepository.DeleteSupplierAsync(Arg.Any<int>()).ReturnsNull();

        var returnResult = await _supplierManager.DeleteSupplierAsync(1);

        await _supplierRepository.Received().DeleteSupplierAsync(1);
        returnResult.Should().BeNull();
    }

}
