using FluentValidation;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back.Manager.Validator
{
    public class NewCustomerValidator : AbstractValidator<NewCustomer>
    {
        public NewCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Address).NotNull().NotEmpty().MinimumLength(3).MaximumLength(200);
            RuleFor(x => x.Cellphone).NotNull().NotEmpty().Matches("[2-9][0-9]{10}").WithMessage("Cell input : [2-9][0-9]{10}");
            RuleFor(x => x.BirthDay).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-110));
            RuleFor(x => x.Gender).NotNull().NotEmpty().Must(MorF).WithMessage("Gender input: 'M' or 'F'");
            RuleFor(x => x.CPF).NotNull().NotEmpty().Matches("[0-9]{11}").Must(CPFValidator);
        }

        private bool MorF(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }

        private bool CPFValidator(string cpf)
        {
            // Removendo caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verificando se o CPF possui 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verificando se todos os dígitos são iguais
            if (cpf.Distinct().Count() == 1)
                return false;

            // Calculando o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            // Verificando o primeiro dígito verificador
            if (int.Parse(cpf[9].ToString()) != digitoVerificador1)
                return false;

            // Calculando o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            // Verificando o segundo dígito verificador
            if (int.Parse(cpf[10].ToString()) != digitoVerificador2)
                return false;

            return true;
        }
    }
}
