using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Consumable;
public sealed class Consumable : Entity
{
    public string Name { get; set; }
    public int Stock { get; protected set; }
    public decimal Price { get; protected set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public IEnumerable<Procedure> Procedures { get; set; }
}
