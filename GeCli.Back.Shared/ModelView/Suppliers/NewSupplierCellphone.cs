﻿using GeCli.Back.Shared.ModelView.CommumClasses;

namespace GeCli.Back.Shared.ModelView.Suppliers;

public class NewSupplierCellphone : NewCellphone, ICloneable
{
    public object Clone()
    {
        return MemberwiseClone();
    }
}
