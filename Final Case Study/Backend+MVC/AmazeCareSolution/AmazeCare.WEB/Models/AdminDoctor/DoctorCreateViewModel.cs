using System.ComponentModel.DataAnnotations;


namespace AmazeCare.WEB.Models.AdminDoctor
{
    public class DoctorCreateViewModel
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Specialty { get; set; }

        [Required, Range(0, 100)]
        public int Experience { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public string Designation { get; set; }



    }

}