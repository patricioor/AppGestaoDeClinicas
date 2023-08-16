using Bogus;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.FakeData.DentistData;
public class NewDentistCellphoneFake : Faker<NewDentistCellphone>
{
    public NewDentistCellphoneFake()
    {
        RuleFor(x => x.Number, p => p.Phone.PhoneNumber("11#########"));
    }
}
