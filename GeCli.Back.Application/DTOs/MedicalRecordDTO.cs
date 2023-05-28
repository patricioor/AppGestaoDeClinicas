using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using GeCli.Back.Domain.Entities;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GeCli.Back.Application.DTOs
{
    public class MedicalRecordDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Complaint is required")]
        [StringLength(1000)]

        public string Complaint { get; set; }
        [StringLength(100)]
        public string? Medicate { get; set; }
        [StringLength(100)]
        public string? Allergy { get; set; }
        [StringLength(100)]
        public string? Disease { get; set; }
        [StringLength(100)]
        public string? Surgery { get; set;}
        [Required(ErrorMessage = "Answer if bleeding was excessive is required")]
        public bool Bleed { get; set;}
        [Required(ErrorMessage = "Answer if the healing was well done is necessary")]
        public bool Heal { get; set;}
        [Required(ErrorMessage = "Medical Record ie required")]
        [MaxLength(5000)]
        public string MedRecord { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Procedure? Procedure { get; set; }
        [DisplayName("Procedures")]
        public int ProcedureId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Dentist? Dentist { get; set; }
        [DisplayName("Dentists")]
        public int DentistId { get;set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Customer? Customer { get; set; }
        [DisplayName("Customers")]
        public int CustomerId { get; set; }
    }
}
