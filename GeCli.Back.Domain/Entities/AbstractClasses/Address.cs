namespace GeCli.Back.Domain.Entities.AbstractClasses
{
    public abstract class Address
    {
        public string Street { get; set; }
        public int CEP { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
    }
}