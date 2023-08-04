using Bogus;
using GeCli.Back.Domain.Entities.Employees;

namespace GeCli.Back._FakeData.DentistData;

public class SpecialtyFake : Faker<Specialty>
{
    public SpecialtyFake()
    {
        var id = new Faker().Random.Number(1, 10);
        RuleFor(p => p.Id, f => id);
        RuleFor(p => p.Description, f => f.Lorem.Word());
    }
}
