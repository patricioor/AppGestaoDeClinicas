using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeCli.Back.Shared.ModelView.User
{
    public class UserView
    {
        public string Login { get; set; }
        public IEnumerable<FunctionView> Functions { get; set; }
    }
}
