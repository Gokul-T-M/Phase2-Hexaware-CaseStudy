using System.ComponentModel.DataAnnotations;

namespace AmazeCare.API.DTOs.AuthDTOs
{
    public class RegisterDoctorDTO
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
        [StringLength(100)]
        public string Specialty { get; set; }

        [Required]
        [Range(0, 60, ErrorMessage = "Experience must be between 0 and 60 years.")]
        public int Experience { get; set; }

        [Required]
        [StringLength(100)]
        public string Qualification { get; set; }

        [Required]
        [StringLength(100)]
        public string Designation { get; set; }
    }
}
