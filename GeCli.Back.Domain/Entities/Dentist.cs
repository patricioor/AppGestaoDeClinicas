using GeCli.Back.Domain.Validation;
using System.Text.RegularExpressions;

namespace GeCli.Back.Domain.Entities
{
    public sealed class Dentist : Entity
    {
        public string Cro { get; set; }

        public Dentist(string name, string cro)
        {
            ValidateDomainName(name);
            ValidateDomainCro(cro);
        }

        public Dentist(int id, string name, string cro)
        {
            ValidateDomainId(id);
            ValidateDomainName(name);
            ValidateDomainCro(cro);
        }

        public void Update(string name, string cro, int employmentId) 
        {
            ValidateDomainName(name);
            ValidateDomainCro(cro);
            EmploymentId = employmentId;
        }

        private void ValidateDomainCro(string cro)
        {
            Regex regex = new Regex("^[0-9]{5}$");
            DomainExceptionValidation.When(!regex.IsMatch(cro), "Invalid CRO.CRO is invalid if it doesn't have 5 digits.");
            Cro = cro;
        }

        public int EmploymentId { get; set; }
        Employment Employment { get; set; }
    }
}
