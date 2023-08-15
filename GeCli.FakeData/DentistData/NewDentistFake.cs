using Bogus;
using Bogus.Extensions.Brazil;
using GeCli.Back.Shared.ModelView.CommunClasses;
using GeCli.Back.Shared.ModelView.Employees;
using GeCli.FakeData.DentistData;

namespace GeCliFakeData.DentistData;

public class NewDentistFake : Faker<NewDentist>
{
    public NewDentistFake()
    {
        var cro = new Faker().Random.Number(10000, 99999);
        RuleFor(p => p.Name, p => p.Person.FirstName);
        RuleFor(p => p.Gender, f => f.PickRandom<NewGender>());
        RuleFor(p => p.CPF, f => f.Person.Cpf());
        RuleFor(p => p.CRO, f => cro.ToString());
        RuleFor(p => p.Cellphones, f => new NewDentistCellphoneFake().Generate(3));
        RuleFor(p => p.Address, f => new NewDentistAddressFake().Generate());
        RuleFor(p => p.BirthDay, f => f.Date.Past());
    }
}
