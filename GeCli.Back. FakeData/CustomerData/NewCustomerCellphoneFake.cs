using Bogus;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back._FakeData.CustomerData;

public class NewCustomerCellphoneFake : Faker<NewCustomerCellphone>
{
    public NewCustomerCellphoneFake()
    {
        RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
    }
}
