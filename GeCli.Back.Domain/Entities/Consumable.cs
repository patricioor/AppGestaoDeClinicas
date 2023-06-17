namespace GeCli.Back.Domain.Entities
{
    public sealed class Consumable : Entity
    {
        public int Stock { get; protected set; }
        //public decimal Price { get; protected set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<Procedure> Procedures { get; set; }
    }
}
