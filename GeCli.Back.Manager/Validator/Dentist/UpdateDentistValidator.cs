using FluentValidation;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back.Manager.Validator.Dentist
{
    public class UpdateDentistValidator : AbstractValidator<UpdateDentist>

    {
        public UpdateDentistValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0);
            Include(new NewDentistValidator());
        }
    }
}
