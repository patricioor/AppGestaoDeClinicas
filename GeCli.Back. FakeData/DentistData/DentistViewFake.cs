using Bogus;
using Bogus.Extensions.Brazil;
using GeCli.Back.Shared.ModelView.CommunClasses;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back._FakeData.DentistData;

public class DentistViewFake : Faker<DentistView>
{
    public DentistViewFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        var cro = new Faker().Random.Number(10000, 99999);
        RuleFor(x => x.Id, _ => id);
        RuleFor(x => x.Name, f => f.Person.FullName);
        RuleFor(x => x.Gender, f => f.PickRandom<NewGender>());
        RuleFor(x => x.CPF, f => f.Person.Cpf());
        RuleFor(x => x.CRO, f => cro.ToString());
        RuleFor(x => x.Cellphones, _ => new DentistCellphoneViewFake().Generate(3));
        RuleFor(x => x.Address, _ => new DentistAddressViewFake());
        RuleFor(x => x.BirthDay, f => f.Date.Past());
        RuleFor(x => x.Specialties, f => new SpecialtyViewFake().Generate(2));
    }
}
