namespace GeCli.Back.Domain.Entities
{
    public sealed class Procedure : Entity
    {
        public Procedure(string name) => ValidateDomainName(name);

        public Procedure(int id, string name)
        {
            ValidateDomainId(id);
            ValidateDomainName(name);
        }

        public void Update(string name, int consumablesId)
        {
            ValidateDomainName(name);
            ConsumableId = consumablesId;
        }

        public MedicalRecord MedicalRecord { get; set; }

        public int ConsumableId { get; set; }
        public IEnumerable<Consumable> Consumables { get; set; }
    }
}
