using Bogus;
using GeCli.Back.Shared.ModelView.CommunClasses;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.FakeData.DentistData
{
    public class DentistAddressViewFake : Faker<DentistAddressView>
    {
        public DentistAddressViewFake()
        {
            RuleFor(x => x.Number, f => f.Address.BuildingNumber());
            RuleFor(x => x.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
            RuleFor(x => x.Street, f => f.Address.StreetAddress());
            RuleFor(x => x.City, f => f.Address.City());
            RuleFor(x => x.State, f => f.PickRandom<NewState>());
            RuleFor(p => p.Complement, f => f.Lorem.Sentence(5));
        }
    }
}
