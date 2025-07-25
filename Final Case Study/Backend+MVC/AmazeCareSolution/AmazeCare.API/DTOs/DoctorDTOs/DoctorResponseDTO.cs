﻿namespace AmazeCare.API.DTOs.DoctorDTOs
{
    public class DoctorResponseDTO
    {
        public int DoctorId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Specialty { get; set; }

        public int Experience { get; set; }

        public string Qualification { get; set; }

        public string Designation { get; set; }
    }
}
