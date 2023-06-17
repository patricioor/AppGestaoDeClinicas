using FluentValidation;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Validator
{
    public class NewAddressValidator : AbstractValidator<NewAddress>
    {
        public NewAddressValidator() 
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
