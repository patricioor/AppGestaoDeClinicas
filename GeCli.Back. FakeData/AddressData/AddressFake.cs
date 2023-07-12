using Bogus;
using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Shared.ModelView.CommunClasses;

namespace GeCli.Back._FakeData.AddressData
{
    public class AddressFake : Faker<CustomerAddress>
    {
        
        public AddressFake(int id)
        {
            RuleFor(x => x.CustomerId, _ => id);
            RuleFor(p => p.Number, f => f.Address.BuildingNumber());
            RuleFor(p => p.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
            RuleFor(p => p.City, f => f.Address.City());
            RuleFor(p => p.State, f => f.PickRandom<State>());
            RuleFor(p => p.Number, f => f.Address.BuildingNumber());
            RuleFor(p => p.Street, f => f.Address.StreetName());
            RuleFor(p => p.Complement, f => f.Lorem.Sentence(5));
        }
    }
}
