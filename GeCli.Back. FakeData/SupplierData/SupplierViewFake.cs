using Bogus;
using Bogus.Extensions.Brazil;
using GeCli.FakeData.ConsumableData;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.FakeData.SupplierData;

public class SupplierViewFake : Faker<SupplierView>
{
    public SupplierViewFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        RuleFor(p => p.Id, _  => id);
        RuleFor(p => p.Name, f => f.Company.CompanyName());
        RuleFor(p => p.CNPJ, f => f.Company.Cnpj());
        RuleFor(p => p.Address, f => new SupplierAddressViewFake().Generate());
        RuleFor(p => p.Cellphones, f => new SupplierCellphoneViewFake().Generate(3));
        RuleFor(p => p.Consumables, f => new ConsumableReferenceFake().Generate(3));
        RuleFor(p => p.Vendor, f => f.Person.FirstName);
    }
}
