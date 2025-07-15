using System.ComponentModel.DataAnnotations;

namespace AmazeCare.API.DTOs.DoctorDTOs
{
    public class DoctorCreateDTO
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
        public string Specialty { get; set; }

        [Required]
        [Range(0, 100)]
        public int Experience { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public string Designation { get; set; }
    }
}
