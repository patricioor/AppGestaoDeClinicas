using FluentAssertions;
using GeCli.Back.Domain.Entities;
using Xunit;

namespace GeCli.Back.Domain.Test
{
    public class CustomerUnitTest
    {
        [Fact(DisplayName = "Create Customer With Valid State")]
        public void CreateCustomer_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Customer(1, "New Customer", "New Address", "85123456789", "01012001", true);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Customer With Negative Id Value")]
        public void CreateCustomer_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Customer(-1, "New Customer", "New Address", "85123456789", "01012001", false);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Customer With Null Name Value")]
        public void CreateCustomer_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Customer(1, null, "New Address", "85987654321", "01012001", true);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Customer With Short Name")]
        public void CreateCustomer_WithShortName_DomainExceptionShortName()
        {
            Action action = () => new Customer(1, "Ne", "New Address", "85987654321", "01012001", false);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Customer With Null Address Value")]
        public void CreateCustomer_WithNullAddressValue_DomainExceptionInvalidAddress()
        {
            Action action = () => new Customer(1, "New Customer", null, "85987654321", "01012001", true);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Customer With Out Limit Address")]
        public void CreateCustomer_WithOutLimitAddress_DomainExceptionOutLimitAddress()
        {
            Action action = () => new Customer(1, "New Customer", "New AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew AddressNew Address", "85987654321", "01012001", false);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Customer With Short Address")]
        public void CreateCustomer_WithShortAddress_DomainExceptionShortAddress()
        {
            Action action = () => new Customer(1, "New Customer", "NewA", "85987654321", "01012001", true);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Customer With Null Cellphone Value")]
        public void CreateCustomer_WithNullCellphoneValue_DomainExceptionInvalidCellphone()
        {
            Action action = () => new Customer(1, "New Customer", "New Address", null, "01012001", false);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Customer With 10 or Minus Char at Cellphone Value")]
        public void CreateCustomer_With10orMinusCellPhoneChar_DomainExceptionInvalidCellphoneValue()
        {
            Action action = () => new Customer(1, "New Customer", "New Address", "5987654321", "01012001", true);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Customer With 12 or More Char at Cellphone Value")]
        public void CreateCustomer_With12orMoreCellPhoneChar_DomainExceptionInvalidCellphoneValue()
        {
            Action action = () => new Customer(1, "New Customer", "New Address", "085987654321", "01012001", false);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }
    }
}
