namespace GeCli.Back.Domain.Entities
{
    public sealed class Procedure : Entity
    {
        public MedicalRecord MedicalRecord { get; set; }

        public int ConsumableId { get; set; }
        public IEnumerable<Consumable> Consumables { get; set; }
    }
}
