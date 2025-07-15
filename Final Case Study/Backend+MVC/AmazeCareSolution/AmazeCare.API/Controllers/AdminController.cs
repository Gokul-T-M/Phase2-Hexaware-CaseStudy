using AmazeCare.API.DTOs.AdminDTOs;
using AmazeCare.BLL.Interfaces;
using AmazeCare.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/admins")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    // GET: All Admins
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var admins = await _adminService.GetAllAdminsAsync();

        var result = admins.Select(a => new AdminResponseDTO
        {
            AdminId = a.AdminId,
            Name = a.Name,
            Email = a.Email
        });

        return Ok(result);
    }

    // GET: Single Admin
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var admin = await _adminService.GetAdminByIdAsync(id);
        if (admin == null) return NotFound();

        var result = new AdminResponseDTO
        {
            AdminId = admin.AdminId,
            Name = admin.Name,
            Email = admin.Email
        };

        return Ok(result);
    }

    // POST: Add Admin
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AdminCreateDTO dto)
    {
        var admin = new Admin
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password
        };

        await _adminService.AddAdminAsync(admin);
        return Ok("Admin added");
    }

    // PUT: Update Admin
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AdminUpdateDTO dto)
    {
        if (id != dto.AdminId) return BadRequest();

        var admin = new Admin
        {
            AdminId = dto.AdminId,
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password
        };

        await _adminService.UpdateAdminAsync(admin);
        return Ok("Admin updated");
    }

    // DELETE: Delete Admin
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _adminService.DeleteAdminAsync(id);
        return Ok("Admin deleted");
    }
}
