using System.ComponentModel.DataAnnotations;

namespace AmazeCare.API.DTOs.AppointmentDTOs
{
    public class AppointmentUpdateDTO
    {
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        [StringLength(500)]
        public string ConsultingDetails { get; set; }

        [StringLength(200)]
        public string Prescriptions { get; set; }

        [StringLength(200)]
        public string RecommendedTests { get; set; }

    }
}
