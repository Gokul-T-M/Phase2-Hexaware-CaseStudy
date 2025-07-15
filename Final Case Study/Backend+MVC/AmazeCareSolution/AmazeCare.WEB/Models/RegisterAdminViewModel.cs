using System.ComponentModel.DataAnnotations;

namespace AmazeCare.WEB.Models
{
    public class RegisterAdminViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
