using Bogus;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.FakeData.CustomerData
{
    public class CustomerCellphoneViewFake : Faker<CustomerCellphoneView>
    {
        public CustomerCellphoneViewFake()
        {
            RuleFor(p => p.Id, f => f.Random.Number(1, 10));
            RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
        }
    }
}
