﻿using FluentValidation;
using GeCli.Back.Manager.Validator.Customer;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back.Manager.Validator.Dentist
{
    public class NewDentistValidator : AbstractValidator<NewDentist>
    {
        public NewDentistValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Cellphones).NotNull().NotEmpty();
            RuleFor(x => x.BirthDay).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-110));
            RuleFor(x => x.Gender).NotNull().NotEmpty().Must(FunctionsValidator.MorF).WithMessage("Gender input: 'M' or 'F'");
            RuleFor(x => x.CPF).NotNull().NotEmpty().Matches("[0-9]{11}").Must(FunctionsValidator.CPFValidator);
            RuleFor(x => x.Address).SetValidator(new NewCustomerAddressValidator());
            RuleFor(x => x.CRO).NotNull().NotEmpty().Matches("[A-z]{2}[0-9]{5}");
        }
    }
}
