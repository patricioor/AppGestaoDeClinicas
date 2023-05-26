using GeCli.Back.Domain.Validation;

namespace GeCli.Back.Domain.Entities
{
    public sealed class Consumable : Entity
    {
        public int Stock { get; protected set; }
        public decimal Price { get; protected set; }

        public Consumable(string name, int stock, decimal price)
        {
            ValidateDomainName(name);
            ValidateDomainConsumables(stock, price);
        }

        public Consumable(int id, string name, int stock, decimal price)
        {
            ValidateDomainId(id);
            ValidateDomainName(name);
            ValidateDomainConsumables(stock, price);
        }

        public void Update(string name, int stock, decimal price, int categoryId) 
        {
            ValidateDomainName(name);
            ValidateDomainConsumables(stock, price);
            CategoryId = categoryId;
        }

        private void ValidateDomainConsumables(int stock, decimal price)
        {
            DomainExceptionValidation.When(stock < 0, "Invalid stock value");
            DomainExceptionValidation.When(price < 0, "Invalid price value");

            Stock = stock;
            Price = price;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
