using AmazeCare.API.DTOs.AuthDTO_s;
using AmazeCare.API.DTOs.AuthDTOs;
using AmazeCare.BLL.Interfaces;
using AmazeCare.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AmazeCare.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IAdminService _adminService;
        private readonly IConfiguration _config;

        public AuthController(
            IPatientService patientService,
            IDoctorService doctorService,
            IAdminService adminService,
            IConfiguration config)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _adminService = adminService;
            _config = config;
        }

        //  PATIENT REGISTRATION (open to all)
        [HttpPost("register/patient")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientDTO dto)
        {
            var existing = (await _patientService.GetAllPatientsAsync())
                .FirstOrDefault(x => x.Email == dto.Email);

            if (existing != null)
                return BadRequest("Email already exists.");

            var patient = new Patient
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                ContactNumber = dto.ContactNumber,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                
            };

            await _patientService.AddPatientAsync(patient);

            var created = (await _patientService.GetAllPatientsAsync())
                .FirstOrDefault(x => x.Email == dto.Email);

            var token = GenerateToken(created.Email, "Patient", created.PatientId);
            return Ok(new { token });
        }

        //  DOCTOR REGISTRATION (admin only)
        [HttpPost("register/doctor")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterDoctor([FromBody] RegisterDoctorDTO dto)
        {
            var existing = (await _doctorService.GetAllDoctorsAsync())
                .FirstOrDefault(x => x.Email == dto.Email);

            if (existing != null)
                return BadRequest("Email already exists.");

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

            var created = (await _doctorService.GetAllDoctorsAsync())
                .FirstOrDefault(x => x.Email == dto.Email);

            var token = GenerateToken(created.Email, "Doctor", created.DoctorId);
            return Ok(new { token });
        }

        //  ADMIN REGISTRATION (open only for first time, later only by admin)
        [HttpPost("register/admin")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminDTO dto)
        {
            var allAdmins = await _adminService.GetAllAdminsAsync();
            bool isFirstAdmin = !allAdmins.Any();

            if (!isFirstAdmin && !(User.Identity?.IsAuthenticated == true && User.IsInRole("Admin")))
                return StatusCode(403, "Already An Admin Exist. Only Existing admins can register new admins!");

            var existing = allAdmins.FirstOrDefault(x => x.Email == dto.Email);
            if (existing != null)
                return BadRequest("Email already exists.");

            var admin = new Admin
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };

            await _adminService.AddAdminAsync(admin);

            var created = (await _adminService.GetAllAdminsAsync())
                .FirstOrDefault(x => x.Email == dto.Email);

            var token = GenerateToken(created.Email, "Admin", created.AdminId);
            return Ok(new { token });
        }

        //  LOGIN (common for all)
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO login)
        {
            // Admin login
            var admin = (await _adminService.GetAllAdminsAsync())
                .FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            if (admin != null)
                return Ok(new { token = GenerateToken(admin.Email, "Admin", admin.AdminId) });

            // Doctor login
            var doctor = (await _doctorService.GetAllDoctorsAsync())
                .FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            if (doctor != null)
                return Ok(new { token = GenerateToken(doctor.Email, "Doctor", doctor.DoctorId) });

            // Patient login
            var patient = (await _patientService.GetAllPatientsAsync())
                .FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            if (patient != null)
                return Ok(new { token = GenerateToken(patient.Email, "Patient", patient.PatientId) });

            return Unauthorized("Invalid credentials");
        }

        //  JWT Generation
        private string GenerateToken(string email, string role, int userId)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["JwtSettings:DurationInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
