using GeCli.Back.Shared.ModelView.CommumClasses;

namespace GeCli.Back.Shared.ModelView.Suppliers;

public class NewSupplierAddress : NewAddress, ICloneable
{
    public object Clone()
    {
        return MemberwiseClone();
    }
}
