using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities;
public sealed class Category : Entity
{
    public string Name { get; set; }

    public IEnumerable<Consumable> Consumables { get; private set; }
}
