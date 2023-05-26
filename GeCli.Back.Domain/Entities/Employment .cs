namespace GeCli.Back.Domain.Entities
{
    public sealed class Employment : Entity
    {
        public Employment(string name) => ValidateDomainName(name);

        public Employment(int id, string name)
        {
            ValidateDomainId(id);
            ValidateDomainName(name);
        }

        public void Update(string name) => ValidateDomainName(name);

        public ICollection<Dentist> Dentists { get; private set; }
    }
}
