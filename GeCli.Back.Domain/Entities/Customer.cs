using GeCli.Back.Domain.Validation;
using System.Text.RegularExpressions;

namespace GeCli.Back.Domain.Entities
{
    public sealed class Customer : Entity
    {
        public string Address { get; protected set; }
        public string Cellphone { get; protected set; }
        public string Birth { get; protected set; }

        public Customer(string name, string address, string cellphone, string birth)
        {
            ValidateDomainName(name);
            ValidateDomainCustomer(address, cellphone, birth);
        }

        public Customer(int id, string name, string address, string cellphone, string birth)
        {
            ValidateDomainId(id);
            ValidateDomainName(name);
            ValidateDomainCustomer(address, cellphone, birth);
        }

        public void Update(string name, string address, string cellphone, string birth, int responsibleId)
        {
            ValidateDomainName(name);
            ValidateDomainCustomer(address, cellphone, birth);

            ResponsibleId = responsibleId;
        }

        public int? ResponsibleId { get; set; }
        public Responsible Responsible { get; set; }

        public IEnumerable<MedicalRecord> MedicalRecords { get; set; }

        private void ValidateDomainCustomer(string address, string cellphone, string birth)
        {
            Regex regexCell = new Regex("^\\d{11}$");
            Regex regexBirth = new Regex("^\\d{8}$");

            DomainExceptionValidation.When(String.IsNullOrEmpty(address), "Invalid address.Address is required");
            DomainExceptionValidation.When(address.Length > 200, "The character limit of 200 has been exceeded");
            DomainExceptionValidation.When(address.Length < 5, "Invalid address. Too short, minimum 5 characters");

            DomainExceptionValidation.When(String.IsNullOrEmpty(cellphone), "Invalid cellphone.Cellphone record is required");
            DomainExceptionValidation.When(!regexCell.IsMatch(cellphone), "The cell phone number must contain exactly 11 numbers, 2 of the ddd and 9 of the line.");

            DomainExceptionValidation.When(String.IsNullOrEmpty(birth), "Invalid Date of Birth.Date of birth is required");
            DomainExceptionValidation.When(!regexBirth.IsMatch(birth), "Date of Birth need contains 8 numbers.");

            Address = address;
            Cellphone = cellphone;
            Birth = birth;
        }
    }
}
