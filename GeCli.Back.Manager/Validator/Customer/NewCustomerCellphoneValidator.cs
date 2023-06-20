using FluentValidation;
using GeCli.Back.Shared.ModelView.CommumClasses;

namespace GeCli.Back.Manager.Validator.Customer
{
    public class NewCustomerCellphoneValidator : AbstractValidator<NewCellphone>
    {
        public NewCustomerCellphoneValidator()
        {
            RuleFor(x => x.Number).NotNull().NotEmpty().Matches("[1-9]{4}[0-9]{7}").WithMessage("Cell input : [1-9]{4}[0-9]{7}");
        }
    }
}