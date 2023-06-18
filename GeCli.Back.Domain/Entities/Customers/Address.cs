namespace GeCli.Back.Domain.Entities.Customers
{
    public class Address
    {
        public int CustomerId { get; set; }
        public string Street { get; set; }
        public int CEP { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }

        public Customer Customer { get; set; }
    }
}