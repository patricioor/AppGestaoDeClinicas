using FluentAssertions;
using GeCli.Back.Domain.Entities;
using Xunit;

namespace GeCli.Back.Domain.Test
{
    public class ResponsibleUnitTest
    {
        [Fact(DisplayName = " Create Responsible With Valid State")]
        public void CreateResponsible_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Responsible(1, "New Procedure");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Responsible With Invalid Id Value")]
        public void CreateResponsible_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Responsible(-1, "New Procedure");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid 'id' value");
        }

        [Fact(DisplayName = "Create Responsible With Null Name Value")]
        public void CreateResponsible_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Responsible(1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Responsible With Short Name")]
        public void CreateResponsible_WithShortName_DomainExceptionShortName()
        {
            Action action = () => new Responsible(1, "Ne");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name. Too short, minimum 3 characters");
        }
    }
}
