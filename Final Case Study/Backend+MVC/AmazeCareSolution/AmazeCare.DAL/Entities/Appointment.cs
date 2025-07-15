using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazeCare.DAL.Entities
{
    public class Appointment
    {
        [Key]
        [Range(1, int.MaxValue, ErrorMessage = "AppointmentId must be greater than 0")]
        public int AppointmentId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [RegularExpression("^(Scheduled|Completed|Cancelled)$", 
            ErrorMessage = "Status must be Scheduled, Completed, or Cancelled.")]
        public string Status { get; set; } // Scheduled, Completed

        [StringLength(200)]
        public string? Symptoms { get; set; }

        [StringLength(500)]
        public string? ConsultingDetails { get; set; }

        [StringLength(300)]
        public string? Prescriptions { get; set; }

        [StringLength(300)]
        public string? RecommendedTests { get; set; }

        [Required]
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
