using FluentAssertions;
using GeCli.Back.Domain.Entities;
using Xunit;

namespace GeCli.Back.Domain.Test
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidState_ResultObjectValidState()
        {
            Action action = () => new Category(1, "New Category");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Invalid Id Value")]
        public void CreateCategory_WithInvalidIdValue_DomainExceptionNegativeId()
        {
            Action action = () => new Category(-1, "New Category");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Null Name Value")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Short Name")]
        public void CreateCategory_WithShortName_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ne");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }
    }
}
