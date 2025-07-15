using System.ComponentModel.DataAnnotations;

namespace AmazeCare.WEB.Models.AdminPatient
{
    public class PatientCreateViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required]
        //[MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid contact number.")]
        public string ContactNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression("Male|Female|Other", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; }

        //[Required]
        [StringLength(500)]
        public string? PreviousMedicalRecords { get; set; }
    }
}
