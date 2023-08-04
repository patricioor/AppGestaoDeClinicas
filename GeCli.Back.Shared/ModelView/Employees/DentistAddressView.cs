using GeCli.Back.Shared.ModelView.CommumClasses;

namespace GeCli.Back.Shared.ModelView.Employees
{
    public class DentistAddressView : NewAddress, ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
