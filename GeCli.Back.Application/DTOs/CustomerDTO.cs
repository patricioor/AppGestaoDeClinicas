using GeCli.Back.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeCli.Back.Application.DTOs
{
    public class CustomerDTO
    {
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        public string Cellphone { get; set; }

        public DateTime Birth { get; set; }

        public Responsible? Resposible { get; set; }

        public int? ResponsibleId { get; set; }
    }
}
