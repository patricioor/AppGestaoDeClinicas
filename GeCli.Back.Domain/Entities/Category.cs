using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GeCli.Back.Domain.Entities
{
    public sealed class Category : Entity
    {
        public Category(string name)
        {
            ValidateDomainName(name);
        }

        public Category(int id, string name)
        {
            ValidateDomainId(id);
            ValidateDomainName(name);
        }

        public void Update(string name)
        {
            ValidateDomainName(name);
        }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Consumable> Consumables { get; private set; }

    }
}
