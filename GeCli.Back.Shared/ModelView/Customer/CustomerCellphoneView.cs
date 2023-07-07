using GeCli.Back.Shared.ModelView.CommumClasses;

namespace GeCli.Back.Shared.ModelView.Customer
{
    public class CustomerCellphoneView : NewCellphone, ICloneable
    {
        public int Id { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}