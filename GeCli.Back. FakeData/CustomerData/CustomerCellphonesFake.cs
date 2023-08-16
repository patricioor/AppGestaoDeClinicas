using Bogus;
using GeCli.Back.Domain.Entities.Customers;

namespace GeCli.FakeData.CustomerData;

public class CustomerCellphonesFake : Faker<CustomerCellphone>
{
    public CustomerCellphonesFake(int id)
    {
        RuleFor(x => x.CustomerId, _ => id);
        RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
    }
}
