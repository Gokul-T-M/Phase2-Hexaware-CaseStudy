using System.ComponentModel.DataAnnotations;

namespace AmazeCare.API.DTOs.AuthDTOs
{
    public class RegisterPatientDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        //[MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string ContactNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression("Male|Female|Other", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; }


    }
}
