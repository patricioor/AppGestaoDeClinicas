namespace GeCli.Back.Manager.Validator
{
    internal static class FunctionsValidator
    {

        public static bool CPFValidator(string cpf)
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
