using FluentValidation;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Validator
{
    public class NewCellphoneValidator : AbstractValidator<NewCellphone>
    {
        public NewCellphoneValidator()
        {
            RuleFor(x => x.Number).NotNull().NotEmpty().Matches("[1-9]{4}[0-9]{7}").WithMessage("Cell input : [1-9]{4}[0-9]{7}");
        }
    }
}