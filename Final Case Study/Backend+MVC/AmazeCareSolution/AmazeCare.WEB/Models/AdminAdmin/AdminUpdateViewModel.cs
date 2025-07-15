using System.ComponentModel.DataAnnotations;

namespace AmazeCare.WEB.Models.AdminAdmin
{
    public class AdminUpdateViewModel
    {
        [Required]
        public int AdminId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
