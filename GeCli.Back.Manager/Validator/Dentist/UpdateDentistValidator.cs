using FluentValidation;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back.Manager.Validator.Dentist
{
    public class UpdateDentistValidator : AbstractValidator<UpdateDentist>

    {
        public UpdateDentistValidator(ISpecialtyRepository repository)
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0);
            Include(new NewDentistValidator(repository));
        }
    }
}
