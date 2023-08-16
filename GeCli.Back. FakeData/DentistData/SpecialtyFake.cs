using Bogus;
using GeCli.Back.Domain.Entities.Employees;

namespace GeCli.FakeData.DentistData;

public class SpecialtyFake : Faker<Specialty>
{
    public SpecialtyFake()
    {
        var id = new Faker().Random.Number(1, 500);
        RuleFor(p => p.Id, f => id);
        RuleFor(p => p.Description, f => f.Lorem.Word());
    }
}
