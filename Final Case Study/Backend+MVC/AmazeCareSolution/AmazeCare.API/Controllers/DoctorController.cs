using AmazeCare.API.DTOs.DoctorDTOs;
using AmazeCare.BLL.Interfaces;
using AmazeCare.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/doctors")]
[Authorize(Roles = "Admin,Doctor")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    // Only Admin can view all doctors
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var doctors = await _doctorService.GetAllDoctorsAsync();

        var result = doctors.Select(d => new DoctorResponseDTO
        {
            DoctorId = d.DoctorId,
            Name = d.Name,
            Email = d.Email,
            Specialty = d.Specialty,
            Experience = d.Experience,
            Qualification = d.Qualification,
            Designation = d.Designation
        });

        return Ok(result);
    }

    // Doctors can view their own profile
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        if (User.IsInRole("Doctor"))
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            if (id != userId) return Forbid();
        }

        var doctor = await _doctorService.GetDoctorByIdAsync(id);
        if (doctor == null) return NotFound();

        var result = new DoctorResponseDTO
        {
            DoctorId = doctor.DoctorId,
            Name = doctor.Name,
            Email = doctor.Email,
            Specialty = doctor.Specialty,
            Experience = doctor.Experience,
            Qualification = doctor.Qualification,
            Designation = doctor.Designation
        };

        return Ok(result);
    }

    // Only Admin can add doctors
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] DoctorCreateDTO dto)
    {
        var doctor = new Doctor
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            Specialty = dto.Specialty,
            Experience = dto.Experience,
            Qualification = dto.Qualification,
            Designation = dto.Designation
        };

        await _doctorService.AddDoctorAsync(doctor);
        return Ok("Doctor added");
    }

    // Doctors can update their own profile
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DoctorUpdateDTO dto)
    {
        if (User.IsInRole("Doctor"))
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            if (id != userId || id != dto.DoctorId)
                return Forbid();
        }

        var existingDoctor = await _doctorService.GetDoctorByIdAsync(id);
        if (existingDoctor == null)
            return NotFound("Doctor not found.");

        // Update only the fields we want to allow updating
        existingDoctor.Name = dto.Name;
        existingDoctor.Email = dto.Email;
        existingDoctor.Password = dto.Password;
        existingDoctor.Specialty = dto.Specialty;
        existingDoctor.Experience = dto.Experience;
        existingDoctor.Qualification = dto.Qualification;
        existingDoctor.Designation = dto.Designation;

        await _doctorService.UpdateDoctorAsync(existingDoctor);
        return Ok("Doctor updated");
    }

    // Only Admin can delete doctors
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _doctorService.DeleteDoctorAsync(id);
        return Ok("Doctor deleted");
    }
}
