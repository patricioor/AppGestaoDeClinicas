﻿using GeCli.Back.Shared.ModelView.CommumClasses;

namespace GeCli.Back.Shared.ModelView.Customer
{
    public class NewCustomerCellphone : NewCellphone, ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
