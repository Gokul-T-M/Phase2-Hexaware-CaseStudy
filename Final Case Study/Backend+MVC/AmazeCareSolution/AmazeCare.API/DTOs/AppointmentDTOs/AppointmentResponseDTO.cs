using System.ComponentModel.DataAnnotations;

namespace AmazeCare.API.DTOs.AppointmentDTOs
{
    public class AppointmentResponseDTO
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public string DoctorName { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string Symptoms { get; set; }
        public string Status { get; set; } // e.g. Scheduled, Completed, Cancelled
        public string? ConsultingDetails { get; set; }
        public string? Prescriptions { get; set; }
        public string? RecommendedTests { get; set; }
    }
}
