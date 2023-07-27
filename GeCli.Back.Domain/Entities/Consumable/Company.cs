using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Consumable;

public class Company : Entity
{
    public string Name { get; set; }
    public string CNPJ { get; set; }
    public Address Address { get; set; }

}
