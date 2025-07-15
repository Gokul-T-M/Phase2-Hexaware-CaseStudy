using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazeCare.DAL.Entities
{
    public class Admin
    {
        [Key]
        [Range(1, int.MaxValue, ErrorMessage = "AdminId must be greater than 0")]
        public int AdminId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
