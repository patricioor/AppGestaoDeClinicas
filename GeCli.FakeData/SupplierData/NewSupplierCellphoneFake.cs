using Bogus;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.FakeData.SupplierData;

public class NewSupplierCellphoneFake : Faker<NewSupplierCellphone>
{
    public NewSupplierCellphoneFake()
    {
        RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
    }
}
