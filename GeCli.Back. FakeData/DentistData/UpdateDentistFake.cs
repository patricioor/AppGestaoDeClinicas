using Bogus;
using Bogus.Extensions.Brazil;
using GeCli.Back.Shared.ModelView.CommunClasses;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back._FakeData.DentistData
{
    public class UpdateDentistFake : Faker<UpdateDentist>
    {
        public UpdateDentistFake()
        {
            var id = new Faker().Random.Number(1, 999);
            var cro = new Faker().Random.Number(10000, 99999);
            RuleFor(p => p.Id, _ => id);
            RuleFor(p => p.Name, f => f.Person.FirstName);
            RuleFor(p => p.Gender, f => f.PickRandom<NewGender>());
            RuleFor(p => p.CPF, f => f.Person.Cpf());
            RuleFor(p => p.Cellphones, f => new NewDentistCellphoneFake().Generate(3));
            RuleFor(p => p.Address, f => new NewDentistAddressFake().Generate());
            RuleFor(p => p.BirthDay, f => f.Date.Past());
        }
    }
}
