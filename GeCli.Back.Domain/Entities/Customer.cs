using GeCli.Back.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeCli.Back.Domain.Entities
{
    public sealed class Customer : Entity
    {
        public string Address { get; protected set; }
        public string Cellphone { get; protected set; }
        public string Birth { get; protected set; }
        public bool Reponsible { get; protected set; }

        public Customer(string name,string address, string cellphone, string birth, bool responsible)
        {
            ValidateDomainName(name);
            ValidateDomainCustomer(address, cellphone, birth, responsible);
        }

        public Customer(int id, string name, string address, string cellphone, string birth, bool responsible)
        {
            ValidateDomainId(id);
            ValidateDomainName(name);
            ValidateDomainCustomer(address, cellphone, birth, responsible);
        }

        public void Update(string name, string address, string cellphone, string birth, bool responsible, int responsibleId)
        {
            ValidateDomainName(name);
            ValidateDomainCustomer(address, cellphone, birth, responsible);

            if(responsible)
                ResponsibleId = responsibleId; 
        }

        public int ResponsibleId { get; set; }
        public Responsible Responsible { get; set; }

        private void ValidateDomainCustomer(string address, string cellphone, string birth, bool responsible)
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
            Reponsible = responsible;
        }

    }
}
