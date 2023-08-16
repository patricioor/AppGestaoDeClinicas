using Bogus;
using Bogus.Extensions.Brazil;
using GeCli.FakeData.ConsumableData;
using GeCli.Back.Shared.ModelView.Suppliers;
using GeCli.FakeData.SupplierData;

namespace GeCli.FakeData.SupplierData;

public class UpdateSupplierFake : Faker<UpdateSupplier>
{
    public UpdateSupplierFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        RuleFor(p => p.Id, _ => id);
        RuleFor(p => p.Name, f => f.Company.CompanyName());
        RuleFor(p => p.CNPJ, f => f.Company.Cnpj());
        RuleFor(p => p.Address, f => new NewSupplierAddressFake().Generate());
        RuleFor(p => p.Cellphones, f => new NewSupplierCellphoneFake().Generate(2));
        RuleFor(p => p.Consumables, f => new ConsumableReferenceFake().Generate(2));
    }
}
