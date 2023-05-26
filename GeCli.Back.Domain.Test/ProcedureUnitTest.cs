using FluentAssertions;
using GeCli.Back.Domain.Entities;
using Xunit;

namespace GeCli.Back.Domain.Test
{
    public class ProcedureUnitTest
    {
        [Fact(DisplayName = " Create Procedure With Valid State")]
        public void CreateProcedure_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Procedure(1, "New Procedure");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Producre With Invalid Id Value")]
        public void CreateProcedure_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Procedure(-1, "New Procedure");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid 'id' value");
        }

        [Fact(DisplayName = "Create Procedure With Null Name Value")]
        public void CreateProcedure_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Procedure(1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Procedure With Short Name")]
        public void CreateProcedure_WithShortName_DomainExceptionShortName()
        {
            Action action = () => new Procedure(1, "Ne");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name. Too short, minimum 3 characters");
        }
    }
}
