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

        var control = _mapper.Map<List<Supplier>, List<SupplierFake>>(listSuppliers);
        var returnResult = await _supplierManager.GetSuppliersAsync();

        await _supplierRepository.Received().GetSuppliersAsync();
        returnResult.Should().BeEquivalentTo(control);
    }

}
