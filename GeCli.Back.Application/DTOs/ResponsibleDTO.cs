using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeCli.Back.Application.DTOs
{
    public class ResponsibleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
