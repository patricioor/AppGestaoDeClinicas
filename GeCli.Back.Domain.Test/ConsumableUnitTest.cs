using FluentAssertions;
using GeCli.Back.Domain.Entities;
using Xunit;

namespace GeCli.Back.Domain.Test
{
    public class ConsumableUnitTest
    {
        [Fact(DisplayName = "Create Consumable With Valid State")]
        public void CreateConsumable_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Consumable(1,"New Consumable", 10, 10.0m);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Consumable With Negative Id Value")]
        public void CreateConsumable_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Consumable(-1, "New Consumable", 10, 10.0m);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Consumable With Null Name Value")]
        public void CreateConsumable_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Consumable(1, null, 10, 10.0m);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Consumable With Short Name")]
        public void CreateConsumable_WithShortName_DomainExceptionShortName()
        {
            Action action = () => new Consumable(1, "Ne", 10, 10.0m);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Consumable With Negative Stock Value")]
        public void CreateConsumable_WithNegativeStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Consumable(1, "New Consumable", -10, 10.0m);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Consumable With Negative Price Value")]
        public void CreateConsumable_WithNegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Consumable(1, "New Consumable", 10, -10.0m);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }
    }
}
