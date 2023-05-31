using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Application.DTOs
{
    public class ProcedureDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        public IEnumerable<Consumable> Consumables { get; set; }
    }
}
