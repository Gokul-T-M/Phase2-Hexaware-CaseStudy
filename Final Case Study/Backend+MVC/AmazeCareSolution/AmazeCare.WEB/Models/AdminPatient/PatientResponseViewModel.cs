namespace AmazeCare.WEB.Models.AdminPatient
{
    public class PatientResponseViewModel
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PreviousMedicalRecords { get; set; }
    }
}
