using Bogus;
using Bogus.Extensions.Brazil;
using GeCli.Back.Domain.Entities.Suppliers;
using GeCli.FakeData.ConsumableData;

namespace GeCli.FakeData.SupplierData;

public class SupplierFake : Faker<Supplier>
{
    public SupplierFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        RuleFor(p => p.Id, _ => id);
        RuleFor(p => p.Name, f => f.Company.CompanyName());
        RuleFor(p => p.CNPJ, f => f.Company.Cnpj());
        RuleFor(p => p.Address, f => new SupplierAddressFake(id));
        RuleFor(p => p.Cellphones, f => new SupplierCellphoneFake(id).Generate(2));
        RuleFor(p => p.Consumables, f => new ConsumableFake().Generate(2));
        RuleFor(p => p.Vendor, f => f.Person.FirstName);
    }
}
