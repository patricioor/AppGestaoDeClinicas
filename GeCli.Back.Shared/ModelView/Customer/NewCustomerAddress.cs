﻿using GeCli.Back.Shared.ModelView.CommumClasses;

namespace GeCli.Back.Shared.ModelView.Customer
{
    public class NewCustomerAddress : NewAddress, ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
