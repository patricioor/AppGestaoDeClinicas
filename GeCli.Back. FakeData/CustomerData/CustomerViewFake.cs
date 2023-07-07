using Bogus;
using Bogus.Extensions.Brazil;
using GeCli.Back._FakeData.AddressData;
using GeCli.Back._FakeData.CellphoneData;
using GeCli.Back.Shared.ModelView.CommunClasses;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back._FakeData.CustomerData
{
    public class CustomerViewFake : Faker<CustomerView>
    {
        public CustomerViewFake()
        {
            var id = new Faker().Random.Number(1, 99);
            RuleFor(p => p.Id, f => id);
            RuleFor(p => p.Name, f => f.Person.FullName);
            RuleFor(p => p.Gender, f => f.PickRandom<NewGender>());
            RuleFor(p => p.CPF, f => f.Person.Cpf());
            RuleFor(p => p.Address, f => new AddressViewFake());
            RuleFor(p => p.Cellphones, f => new CellphoneViewFake().Generate(3));
            RuleFor(p => p.BirthDay, f => f.Date.Past());
        }
    }
}
