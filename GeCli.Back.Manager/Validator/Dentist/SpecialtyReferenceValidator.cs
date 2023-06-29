using FluentValidation;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back.Manager.Validator.Dentist;

public class SpecialtyReferenceValidator : AbstractValidator<SpecialtyReference>
{
    public SpecialtyReferenceValidator() 
    {
        RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0);
    }
}
