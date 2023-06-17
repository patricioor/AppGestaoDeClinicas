using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeCli.Back.Shared.ModelView.ErrorMessage
{
    public class ErrorMessage
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }

        public ErrorMessage(string id)
        {
            Id = id;
            Date = DateTime.Now;
            Message = "Inexpected Error";
        }
    }
}
