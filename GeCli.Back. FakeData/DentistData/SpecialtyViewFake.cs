using Bogus;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back._FakeData.DentistData;

public class SpecialtyViewFake : Faker<SpecialtyView>
{
    public SpecialtyViewFake()
    {
        var id = new Faker().PickRandom(1, 500);
        RuleFor(p => p.Id, _ =>  id);
        RuleFor(p => p.Description, f => f.Lorem.Word());
    }
}
