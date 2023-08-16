using Bogus;
using Bogus.Extensions.Brazil;
using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Employees;

namespace GeCli.FakeData.DentistData;

public class DentistFake : Faker<Dentist>
{
    public DentistFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        var cro = new Faker().Random.Number(10000, 99999);
        RuleFor(x => x.Id, _ => id);
        RuleFor(x => x.Name, f => f.Person.FullName);
        RuleFor(x => x.Gender, f => f.PickRandom<Gender>());
        RuleFor(x => x.CPF, f => f.Person.Cpf());
        RuleFor(x => x.CRO, f => cro.ToString());
        RuleFor(x => x.Cellphones, _ => new DentistCellphoneFake(id).Generate(2));
        RuleFor(x => x.Address, _ => new DentistAddressFake(id));
        RuleFor(x => x.BirthDay, f => f.Date.Past());
        RuleFor(x => x.CreationDate, f => f.Date.Past());
        RuleFor(x => x.LastUpdate, f => f.Date.Past());
        RuleFor(x => x.Specialties, f => new SpecialtyFake().Generate(2));
    }
}
