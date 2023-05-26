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
            ConsumablesId = consumablesId;
        }

        public int ConsumablesId { get; set; }
        public Consumable Consumable { get; set; }
    }
}
