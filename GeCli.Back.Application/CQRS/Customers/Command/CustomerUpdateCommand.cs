using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeCli.Back.Application.CQRS.Customers.Command
{
    public class CustomerUpdateCommand : CustomerCommand
    {
        public int Id { get; set; }
    }
}
