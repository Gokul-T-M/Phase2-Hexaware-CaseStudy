using System.ComponentModel.DataAnnotations;

namespace AmazeCare.API.DTOs.AppointmentDTOs
{
    public class AppointmentCreateDTO
    {
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [StringLength(200)]
        public string Symptoms { get; set; }
    }
}
