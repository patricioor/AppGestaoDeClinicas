using FluentValidation;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Validator
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomer>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0);
            Include(new NewCustomerValidator());
        }
    }
}
