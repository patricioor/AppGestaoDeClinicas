using Bogus;
using GeCli.Back.Shared.ModelView.CommunClasses;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back._FakeData.CustomerData;

public class UpdateCustomerFake : Faker<UpdateCustomer>
{
    public UpdateCustomerFake()
    {
        var id = new Faker().Random.Number(1, 100);
        RuleFor(o => o.Id,_=> id);
        RuleFor(o => o.Name, f => f.Person.FullName);
        RuleFor(o => o.Gender, f => f.PickRandom<NewGender>());
        RuleFor(o => o.Address, _ => new NewCustomerAddressFake().Generate());
        RuleFor(o => o.Cellphones, _ => new NewCustomerCellphoneFake().Generate(3));
        RuleFor(o => o.BirthDay, f => f.Date.Past());
    }
}
