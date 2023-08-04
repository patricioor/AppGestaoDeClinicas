using Bogus;
using GeCli.Back.Domain.Entities.Employees;

namespace GeCli.Back._FakeData.DentistData;

public class DentistCellphoneFake : Faker<DentistCellphone>
{
    public DentistCellphoneFake(int id)
    {
        RuleFor(x => x.DentistId, _ => id);
        RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
    }
}
