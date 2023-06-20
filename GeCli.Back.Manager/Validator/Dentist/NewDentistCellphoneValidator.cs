using FluentValidation;
using GeCli.Back.Shared.ModelView.CommumClasses;

namespace GeCli.Back.Manager.Validator.Dentist
{
    public class NewDentistCellphoneValidator : AbstractValidator<NewCellphone>
    {
        public NewDentistCellphoneValidator()
        {
            RuleFor(x => x.Number).NotNull().NotEmpty().Matches("[1-9]{4}[0-9]{7}").WithMessage("Cell input : [1-9]{4}[0-9]{7}");
        }
    }
}
