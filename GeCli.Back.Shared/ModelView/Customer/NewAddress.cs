using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeCli.Back.Shared.ModelView.Customer
{
    public class NewAddress
    {
        /// <example>60000000</example>
        public int CEP { get; set; }
        /// <example>Rua dos Loucos</example>
        public string Street { get; set; }
        /// <example>Fortaleza</example>
        public string City { get; set; }
        /// <example>CE</example>
        public string State { get; set; }
        /// <summary> Letters can be inserted next to the number</summary>
        /// <example>0</example>
        public string Number { get; set; }
        /// <example>APTO 200</example>
        public string Complement { get; set; }
    }
}
