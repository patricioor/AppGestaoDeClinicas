using Bogus;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back._FakeData.DentistData
{
    public class DentistCellphoneViewFake : Faker<DentistCellphoneView>
    {
        public DentistCellphoneViewFake()
        {
            RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
        }
    }
}
