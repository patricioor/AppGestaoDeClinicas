using Bogus;
using GeCli.Back.Shared.ModelView.CommunClasses;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back._FakeData.DentistData;

public class NewDentistAddressFake : Faker<NewDentistAddress>
{
    public NewDentistAddressFake()
    {
        RuleFor(p => p.Number, f => f.Address.BuildingNumber());
        RuleFor(p => p.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
        RuleFor(p => p.Street, f => f.Address.StreetName());
        RuleFor(p => p.Number, f => f.Address.BuildingNumber());
        RuleFor(p => p.Complement, f => f.Lorem.Sentence(2));
        RuleFor(p => p.City, f => f.Address.City());
        RuleFor(p => p.State, f => f.PickRandom<NewState>());
    }
}
