using GeCli.Back._FakeData.SupplierData;
using GeCli.Back.API.Controllers;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Suppliers;
using NSubstitute;
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


    //Inserir ICloneable
    [Fact]
    public async Task GetSuppliers_Ok()
    {
        var control = new List<SupplierView>();
        
    }
}
