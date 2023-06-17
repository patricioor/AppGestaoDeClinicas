using FluentValidation;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Validator
{
    public class NewCustomerValidator : AbstractValidator<NewCustomer>
    {
        public NewCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Cellphone).NotNull().NotEmpty().Matches("[1-9]{4}[0-9]{7}").WithMessage("Cell input : [1-9]{4}[0-9]{7}");
            RuleFor(x => x.BirthDay).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-110));
            RuleFor(x => x.Gender).NotNull().NotEmpty().Must(MorF).WithMessage("Gender input: 'M' or 'F'");
            RuleFor(x => x.CPF).NotNull().NotEmpty().Matches("[0-9]{11}").Must(CPFValidator);
            RuleFor(x => x.Address).SetValidator(new NewAddressValidator());
        }

        private bool MorF(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }

        private bool CPFValidator(string cpf)
        {
            // Removing non-numeric characters
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Checking if the CPF has 11 digits
            if (cpf.Length != 11)
                return false;

            // Checking if all digits are equal
            if (cpf.Distinct().Count() == 1)
                return false;

            // Calculating the first check digit
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int remainder = sum % 11;
            int digitCheck1 = remainder < 2 ? 0 : 11 - remainder;

            // Checking the first check digit
            if (int.Parse(cpf[9].ToString()) != digitCheck1)
                return false;

            // Calculating the second check digit
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            remainder = sum % 11;
            int digitCheck2 = remainder < 2 ? 0 : 11 - remainder;

            // Checking the second check digit
            if (int.Parse(cpf[10].ToString()) != digitCheck2)
                return false;

            return true;
        }
    }
}
