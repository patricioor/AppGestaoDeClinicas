using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Application.DTOs
{
    public class DentistDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CRO is required")]
        [StringLength(5)]
        [DisplayName("CRO")]
        public string Cro { get; set; }

        public Employment? Employment { get; set; }

        [DisplayName("List of employment relationships")]
        public int EmploymentId { get; set; }
    }
}
