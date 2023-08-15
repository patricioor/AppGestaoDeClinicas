using Bogus;
using GeCli.Back.Shared.ModelView.CommunClasses;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.FakeData.SupplierData;

public class NewSupplierAddressFake : Faker<NewSupplierAddress>
{
    public NewSupplierAddressFake()
    {
        RuleFor(x => x.Number, f => f.Address.BuildingNumber());
        RuleFor(x => x.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
        RuleFor(x => x.Street, f => f.Address.StreetAddress());
        RuleFor(x => x.City, f => f.Address.City());
        RuleFor(x => x.State, f => f.PickRandom<NewState>());
        RuleFor(p => p.Complement, f => f.Lorem.Sentence(5));
    }
}
