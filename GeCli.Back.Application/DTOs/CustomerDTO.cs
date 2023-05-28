using GeCli.Back.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeCli.Back.Application.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(200)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Cellphone is required")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Cellphone")]
        public string Cellphone { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public string Birth { get; set; }

        public Responsible? Resposible { get; set; }

        [DisplayName("Responsible's list")]
        public int? ResponsibleId { get; set; }
    }
}
