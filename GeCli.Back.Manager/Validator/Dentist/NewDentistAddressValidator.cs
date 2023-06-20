using FluentValidation;
using GeCli.Back.Shared.ModelView.CommumClasses;

namespace GeCli.Back.Manager.Validator.Dentist
{
    public class NewDentistAddressValidator : AbstractValidator<NewAddress>
    {
        public NewDentistAddressValidator()
        {
            RuleFor(p => p.CEP).NotEmpty().NotNull();
            RuleFor(p => p.State).NotNull();
            RuleFor(p => p.City).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(p => p.Street).NotEmpty().NotNull().MaximumLength(150);
            RuleFor(p => p.Number).NotEmpty().NotNull().MaximumLength(10);
            RuleFor(p => p.Complement).MaximumLength(200);
        }
    }
}
