using Bogus;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.FakeData.DentistData;

public class NewSpecialtyFake : Faker<NewSpecialty>
{
    public NewSpecialtyFake()
    {
        RuleFor(p => p.Description, x => x.Lorem.Word());
    }
}
