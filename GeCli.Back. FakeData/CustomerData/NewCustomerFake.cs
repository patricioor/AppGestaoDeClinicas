using Bogus;
using Bogus.Extensions.Brazil;
using GeCli.Back.Shared.ModelView.CommunClasses;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back._FakeData.CustomerData
{
    public class NewCustomerFake : Faker<NewCustomer>
    {
        public NewCustomerFake()
        {
            RuleFor(p => p.Name, f => f.Person.FullName);
            RuleFor(p => p.Gender, f => f.PickRandom<NewGender>());
            RuleFor(p => p.CPF, f => f.Person.Cpf());
            RuleFor(p => p.Cellphones, f => new NewCustomerCellphoneFake().Generate(3));
            RuleFor(p => p.Address, f => new NewCustomerAddressFake().Generate());
            RuleFor(p => p.BirthDay, f => f.Date.Past());
        }
    }
}
