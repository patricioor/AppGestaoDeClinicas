using System.ComponentModel.DataAnnotations;

namespace GeCli.Back.Application.DTOs
{
    public class CategoryDTO
    {
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
