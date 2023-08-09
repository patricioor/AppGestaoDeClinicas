using GeCli.Back.Shared.ModelView.CommumClasses;

namespace GeCli.Back.Shared.ModelView.Suppliers;

public class SupplierCellphoneView : NewCellphone, ICloneable
{
    public object Clone()
    {
        return MemberwiseClone();
    }
}
