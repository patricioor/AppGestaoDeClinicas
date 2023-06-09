using FluentValidation;
using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Manager.Validator
{
    public class NewCategoryValidator : AbstractValidator<Category>
    {
        public NewCategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(10).MaximumLength(100);
        }
    }
}
