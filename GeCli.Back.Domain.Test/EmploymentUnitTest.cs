using FluentAssertions;
using GeCli.Back.Domain.Entities;
using Xunit;

namespace GeCli.Back.Domain.Test
{
    public class EmploymentUnitTest
    {
        [Fact(DisplayName = "Create Employment With Valid State")]
        public void CreateEmployment_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Employment(1, "New Employment");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Employment With Invalid Id Value")]
        public void CreateEmployment_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Employment(-1, "New Employment");
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Employment With Null Name Value")]
        public void CreateEmployment_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Employment(1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Employment With Short Name")]
        public void CreateEmployment_WithShortName_DomainExceptionShortName()
        {
            Action action = () => new Employment(1, "Ne");
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

    }
}
