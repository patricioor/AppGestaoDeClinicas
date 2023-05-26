using FluentAssertions;
using GeCli.Back.Domain.Entities;
using Xunit;

namespace GeCli.Back.Domain.Test
{
    public class DentistUnitTest
    {
        [Fact(DisplayName = "Create Dentist With Valid State")]
        public void CreateDentist_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Dentist(1, "New Dentist", "01234");
            action.Should().NotThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Create Dentist With Invalid Id Value")]
        public void CreateDentist_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Dentist(-1, "New Dentist", "01234");
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Dentist With Null Name Value")]
        public void CreateDentist_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Dentist(1, null, "01234");
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Dentist With Short Name")]
        public void CreateDentist_WithShortName_DomainExceptionShortName()
        {
            Action action = () => new Dentist(1, "Ne", "01234");
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Dentist With 4 or Minus 'CRO' Char")]
        public void CreateDentist_With4orMinusCroLength_DomainExceptionShortCroValue()
        {
            Action action = () => new Dentist(1, "New Dentist", "0123");
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Dentist With 6 or More 'CRO' Char")]
        public void CreateDentist_With5orMoreCroLength_DomainExceptionLongCroValue()
        {
            Action action = () => new Dentist(1, "New Dentist", "012345");
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }
    }
}
