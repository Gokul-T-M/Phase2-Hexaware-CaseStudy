using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazeCare.DAL.Entities
{
    public class Doctor
    {
        [Key]
        [Range(1, int.MaxValue, ErrorMessage = "DoctorId must be greater than 0")]
        public int DoctorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Specialty { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public string Designation { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
