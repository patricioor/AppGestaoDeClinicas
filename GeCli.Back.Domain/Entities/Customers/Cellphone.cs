namespace GeCli.Back.Domain.Entities.Customers
{
    public class Cellphone
    {
        public int CustomerId { get; set; }
        public string Number { get; set; }      
        public Customer Customer { get; set; }
    }
}