using AmazeCare.WEB.Models.AdminAdmin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
public class AdminAdminController : Controller
{
    private readonly HttpClient _httpClient;

    public AdminAdminController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    // GET: AdminAdmin
    public async Task<IActionResult> Index()
    {
        var token = HttpContext.Session.GetString("JWToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        var admins = await _httpClient.GetFromJsonAsync<List<AdminResponseViewModel>>("api/v1/admins");
        return View(admins);
    }

    // GET: AdminAdmin/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var token = HttpContext.Session.GetString("JWToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        var admin = await _httpClient.GetFromJsonAsync<AdminResponseViewModel>($"api/v1/admins/{id}");
        if (admin == null) return NotFound();
        return View(admin);
    }

    // GET: AdminAdmin/Create
    public IActionResult Create() => View();

    // POST: AdminAdmin/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AdminCreateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var token = HttpContext.Session.GetString("JWToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        var response = await _httpClient.PostAsJsonAsync("api/v1/admins", model);
        if (response.IsSuccessStatusCode)
            return RedirectToAction(nameof(Index));

        ModelState.AddModelError("", "Failed to create admin.");
        return View(model);
    }

    // GET: AdminAdmin/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var token = HttpContext.Session.GetString("JWToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        var admin = await _httpClient.GetFromJsonAsync<AdminResponseViewModel>($"api/v1/admins/{id}");
        if (admin == null) return NotFound();

        var model = new AdminUpdateViewModel
        {
            AdminId = admin.AdminId,
            Name = admin.Name,
            Email = admin.Email,
            Password = "" // we must handle password updates differently
        };
        return View(model);
    }

    // POST: AdminAdmin/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(AdminUpdateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);


        var token = HttpContext.Session.GetString("JWToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        var response = await _httpClient.PutAsJsonAsync($"api/v1/admins/{model.AdminId}", model);
        if (response.IsSuccessStatusCode)
            return RedirectToAction(nameof(Index));

        ModelState.AddModelError("", "Failed to update admin.");
        return View(model);
    }

    // GET: AdminAdmin/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var token = HttpContext.Session.GetString("JWToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        var admin = await _httpClient.GetFromJsonAsync<AdminResponseViewModel>($"api/v1/admins/{id}");
        if (admin == null) return NotFound();
        return View(admin);
    }

    // POST: AdminAdmin/Delete/5
    [HttpPost, ActionName("Delete")]//used for routing, because same name cannot be used for multiple methods
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var token = HttpContext.Session.GetString("JWToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        var response = await _httpClient.DeleteAsync($"api/v1/admins/{id}");
        if (response.IsSuccessStatusCode)
            return RedirectToAction(nameof(Index));

        ModelState.AddModelError("", "Failed to delete admin.");
        var admin = await _httpClient.GetFromJsonAsync<AdminResponseViewModel>($"api/v1/admins/{id}");
        return View("Delete", admin);
    }
}
