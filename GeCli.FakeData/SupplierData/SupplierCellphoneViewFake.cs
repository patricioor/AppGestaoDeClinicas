using Bogus;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.FakeData.SupplierData;

public class SupplierCellphoneViewFake : Faker<SupplierCellphoneView>
{
    public SupplierCellphoneViewFake()
    {
        RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
    }
}
