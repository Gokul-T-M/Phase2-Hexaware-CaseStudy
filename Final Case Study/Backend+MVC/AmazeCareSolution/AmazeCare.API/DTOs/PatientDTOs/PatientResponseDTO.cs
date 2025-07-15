using System.ComponentModel.DataAnnotations;

namespace AmazeCare.API.DTOs.PatientDTOs
{
    public class PatientResponseDTO
    {
        public int PatientId { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string ContactNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string? PreviousMedicalRecords { get; set; }
    }
}
