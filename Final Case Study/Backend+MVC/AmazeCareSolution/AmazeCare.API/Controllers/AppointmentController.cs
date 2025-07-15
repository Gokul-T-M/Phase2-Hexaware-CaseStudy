using AmazeCare.API.DTOs.AppointmentDTOs;
using AmazeCare.BLL.Interfaces;
using AmazeCare.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/appointments")]
[Authorize]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    private readonly IPatientService _patientService;
    private readonly IDoctorService _doctorService;

    public AppointmentController(
        IAppointmentService appointmentService,
        IPatientService patientService,
        IDoctorService doctorService)
    {
        _appointmentService = appointmentService;
        _patientService = patientService;
        _doctorService = doctorService;
    }

    // Only Admin can view all appointments
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var appointments = await _appointmentService.GetAllAppointmentsAsync();

        var result = appointments.Select(appointment => new AppointmentResponseDTO
        {
            AppointmentId = appointment.AppointmentId,
            AppointmentDate = appointment.AppointmentDate,
            Status = appointment.Status,
            PatientName = appointment.Patient?.Name,
            PatientId = appointment.PatientId,
            DoctorName = appointment.Doctor?.Name,
            DoctorId = appointment.DoctorId,
            Symptoms = appointment.Symptoms,
            ConsultingDetails = appointment.ConsultingDetails,
            Prescriptions = appointment.Prescriptions,
            RecommendedTests = appointment.RecommendedTests
        });

        return Ok(result);
    }

    // Patient/Doctor/Admin can view one
    [HttpGet("{id}")]
    [Authorize(Roles = "Patient,Doctor,Admin")]
    public async Task<IActionResult> Get(int id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
        if (appointment == null) return NotFound();

        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

        if (User.IsInRole("Patient") && appointment.PatientId != userId)
            return Forbid();

        if (User.IsInRole("Doctor") && appointment.DoctorId != userId)
            return Forbid();

        var dto = new AppointmentResponseDTO
        {
            AppointmentId = appointment.AppointmentId,
            AppointmentDate = appointment.AppointmentDate,
            Status = appointment.Status,
            PatientName = appointment.Patient?.Name,
            PatientId = appointment.PatientId,
            DoctorName = appointment.Doctor?.Name,
            DoctorId = appointment.DoctorId,
            Symptoms = appointment.Symptoms,
            ConsultingDetails = appointment.ConsultingDetails,
            Prescriptions = appointment.Prescriptions,
            RecommendedTests = appointment.RecommendedTests
        };

        return Ok(dto);
    }

    // Patient creates appointment
    [HttpPost]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> Create([FromBody] AppointmentCreateDTO dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);


        var appointment = new Appointment
        {
            AppointmentDate = dto.AppointmentDate,
            Status = "Scheduled",
            DoctorId = dto.DoctorId,
            PatientId = userId,
            Symptoms = dto.Symptoms
        };

        await _appointmentService.AddAppointmentAsync(appointment);
        return Ok("Appointment scheduled");
    }

    // Doctor updates consultation
    [HttpPut("{id}")]
    [Authorize(Roles = "Doctor")]
    public async Task<IActionResult> Update(int id, [FromBody] AppointmentUpdateDTO dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
        if (appointment == null) return NotFound();

        if (appointment.DoctorId != userId || dto.AppointmentId != id)
            return Forbid();

        appointment.ConsultingDetails = dto.ConsultingDetails;
        appointment.Prescriptions = dto.Prescriptions;
        appointment.RecommendedTests = dto.RecommendedTests;
        appointment.Status = "Completed";

        await _appointmentService.UpdateAppointmentAsync(appointment);
        return Ok("Consultation updated");
    }

    // Patient/Admin/Doctor cancel appointment
    [HttpDelete("{id}")]
    [Authorize(Roles = "Patient,Doctor,Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
        if (appointment == null) return NotFound();

        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

        // If the user is a Patient, ensure they own the appointment
        if (User.IsInRole("Patient") && appointment.PatientId != userId)
            return Forbid();

        // If the user is a Doctor, ensure they own the appointment
        if (User.IsInRole("Doctor") && appointment.DoctorId != userId)
            return Forbid();

        // If the user is an Admin, allow deletion without further checks

        await _appointmentService.DeleteAppointmentAsync(id);
        return Ok("Appointment cancelled");
    }


    [HttpGet("doctor/{doctorId}")]
    [Authorize(Roles = "Doctor,Admin")]
    public async Task<IActionResult> GetByDoctor(int doctorId)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var role = User.FindFirst(ClaimTypes.Role)?.Value;
        if (role == "Doctor" && userId != doctorId) return Forbid();


        var appointments = await _appointmentService.GetAppointmentsByDoctorIdAsync(doctorId);

        var appointmentDtos = appointments.Select(a => new AppointmentResponseDTO
        {
            AppointmentId = a.AppointmentId,
            PatientName = a.Patient.Name,
            PatientId = a.PatientId,
            DoctorName = a.Doctor.Name,
            DoctorId = a.DoctorId,
            AppointmentDate = a.AppointmentDate,
            Symptoms = a.Symptoms,
            Status = a.Status,
            ConsultingDetails = a.ConsultingDetails,
            Prescriptions = a.Prescriptions,
            RecommendedTests = a.RecommendedTests
        });

        return Ok(appointmentDtos);
    }

    [HttpGet("patient/{patientId}")]
    [Authorize(Roles = "Patient,Doctor,Admin")]
    public async Task<IActionResult> GetByPatient(int patientId)
    {
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim == null)
            return Unauthorized();

        int userId = int.Parse(userIdClaim);

        if (userRole == "Patient" && userId != patientId)
            return Forbid();

        var appointments = await _appointmentService.GetAppointmentsByPatientIdAsync(patientId);

        var appointmentDtos = appointments.Select(a => new AppointmentResponseDTO
        {
            AppointmentId = a.AppointmentId,
            PatientName = a.Patient.Name,
            PatientId = a.PatientId,
            DoctorName = a.Doctor.Name,
            DoctorId = a.DoctorId,
            AppointmentDate = a.AppointmentDate,
            Symptoms = a.Symptoms,
            Status = a.Status,
            ConsultingDetails = a.ConsultingDetails,
            Prescriptions = a.Prescriptions,
            RecommendedTests = a.RecommendedTests
        });

        return Ok(appointmentDtos);
    }

}
