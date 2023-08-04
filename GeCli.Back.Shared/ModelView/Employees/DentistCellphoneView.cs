using GeCli.Back.Shared.ModelView.CommumClasses;

namespace GeCli.Back.Shared.ModelView.Employees
{
    public class DentistCellphoneView : NewCellphone, ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
