using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeCli.Back.Domain.Entities
{
    public sealed class Responsible : Entity
    {
        public Responsible(string name) 
        {
            ValidateDomainName(name);
        }

        public Responsible(int id, string name)
        {
            ValidateDomainId(id);
            ValidateDomainName(name);
        }

        public void Update(string name) => ValidateDomainName(name);

        public ICollection<Customer> Customers { get; private set; }
    }
}
