namespace GeCli.Back.Domain.Entities
{
    public sealed class Employment : Entity
    {
        public ICollection<Dentist> Dentists { get; private set; }
    }
}
