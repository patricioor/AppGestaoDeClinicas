using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; set; }
        //[JsonIgnore]
        //[IgnoreDataMember]
        //public ICollection<Consumable> Consumables { get; private set; }
    }
}
