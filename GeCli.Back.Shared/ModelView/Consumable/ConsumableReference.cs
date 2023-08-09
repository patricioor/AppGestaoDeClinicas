namespace GeCli.Back.Shared.ModelView.Consumable
{
    public class ConsumableReference : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public object Clone()
        {
            return (ConsumableReference) MemberwiseClone();
        }
    }
}
