using Bogus;
using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Employees;

namespace GeCli.FakeData.DentistData;
public class DentistAddressFake: Faker <DentistAddress>
{
    public DentistAddressFake(int id)
    {
        RuleFor(x => x.DentistId, _ => id);
        RuleFor(x => x.Number, f => f.Address.BuildingNumber());
        RuleFor(x => x.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
        RuleFor(x => x.Street, f => f.Address.StreetAddress());
        RuleFor(x => x.City, f => f.Address.City());
        RuleFor(x => x.State, f => f.PickRandom<State>());
        RuleFor(p => p.Complement, f => f.Lorem.Sentence(5));
    }
}
