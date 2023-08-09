using Bogus;
using Bogus.Extensions.Brazil;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.FakeData.SupplierData;
public class NewSupplierFake: Faker<NewSupplier>
{
    public NewSupplierFake()
    {
        RuleFor(p => p.Name, f => f.Company.CompanyName());
        RuleFor(p => p.CNPJ, f => f.Company.Cnpj());
        RuleFor(p => p.Address, f => new NewSupplierAddressFake().Generate());
        RuleFor(p => p.Cellphones, f => new NewSupplierCellphoneFake().Generate(3));
        RuleFor(p => p.Vendor, f => f.Person.FirstName);
    }
}
