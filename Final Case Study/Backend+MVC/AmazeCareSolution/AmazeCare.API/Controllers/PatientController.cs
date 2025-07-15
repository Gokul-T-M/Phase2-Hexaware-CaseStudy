using AmazeCare.API.DTOs.PatientDTOs;
using AmazeCare.BLL.Interfaces;
using AmazeCare.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/patients")]
[Authorize]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    // Only accessible to Admin/Doctor
    [HttpGet]
    [Authorize(Roles = "Admin,Doctor")]
    public async Task<IActionResult> GetAll()
    {
        var patients = await _patientService.GetAllPatientsAsync();

        var result = patients.Select(p => new PatientResponseDTO
        {
            PatientId = p.PatientId,
            Name = p.Name,
            Email = p.Email,
            ContactNumber = p.ContactNumber,
            DateOfBirth = p.DateOfBirth,
            Gender = p.Gender,
            PreviousMedicalRecords = p.PreviousMedicalRecords
        });

        return Ok(result);
    }

    // Patient can view their own profile; Doctor/Admin can view any
    [HttpGet("{id}")]
    [Authorize(Roles = "Patient,Doctor,Admin")]
    public async Task<IActionResult> Get(int id)
    {
        if (User.IsInRole("Patient"))
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            if (id != userId) return Forbid();
        }

        var patient = await _patientService.GetPatientByIdAsync(id);
        if (patient == null) return NotFound();

        var result = new PatientResponseDTO
        {
            PatientId = patient.PatientId,
            Name = patient.Name,
            Email = patient.Email,
            ContactNumber = patient.ContactNumber,
            DateOfBirth = patient.DateOfBirth,
            Gender = patient.Gender,
            PreviousMedicalRecords = patient.PreviousMedicalRecords
        };

        return Ok(result);
    }

    // Allow anonymous for patient registration
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] PatientCreateDTO dto)
    {
        var patient = new Patient
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            ContactNumber = dto.ContactNumber,
            DateOfBirth = dto.DateOfBirth,
            Gender = dto.Gender,
            PreviousMedicalRecords = dto.PreviousMedicalRecords
            
        };

        await _patientService.AddPatientAsync(patient);
        return Ok("Patient registered successfully");
    }

    // Patient can update their own profile
    [HttpPut("{id}")]
    [Authorize(Roles = "Patient,Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] PatientUpdateDTO dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        if ((ClaimTypes.NameIdentifier == "Patient" && id != userId) || id != dto.PatientId)
            return Forbid();


        var updated = new Patient
        {
            PatientId = dto.PatientId,
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            ContactNumber = dto.ContactNumber,
            DateOfBirth = dto.DateOfBirth,
            Gender = dto.Gender,
            PreviousMedicalRecords = (dto.PreviousMedicalRecords == "") ? null : dto.PreviousMedicalRecords
        };

        await _patientService.UpdatePatientAsync(updated);
        return Ok("Profile updated");
    }

    // Only Admin can delete patients
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _patientService.DeletePatientAsync(id);
        return Ok("Patient deleted");
    }
}
