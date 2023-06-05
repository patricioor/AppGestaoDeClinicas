using System.ComponentModel.DataAnnotations;

namespace GeCli.Back.Application.DTOs
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
