using System.ComponentModel.DataAnnotations;

namespace AmazeCare.API.DTOs.PatientDTOs
{
    public class PatientUpdateDTO
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        [Phone]
        public string ContactNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression("Male|Female|Other")]
        public string Gender { get; set; }

        [StringLength(500)]
        public string? PreviousMedicalRecords { get; set; }
    }
}
