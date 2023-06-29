using FluentValidation;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Validator.Customer
{
    public class NewCustomerValidator : AbstractValidator<NewCustomer>
    {
        public NewCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Cellphones).NotNull().NotEmpty();
            RuleFor(x => x.BirthDay).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-110));
            RuleFor(x => x.Gender).NotNull().WithMessage("Gender input: 'M' or 'F'");
            RuleFor(x => x.CPF).NotNull().NotEmpty().Matches("[0-9]{11}").Must(FunctionsValidator.CPFValidator);
            RuleFor(x => x.Address).SetValidator(new NewCustomerAddressValidator());
        }
    }
}
