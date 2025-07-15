using AmazeCare.WEB.Models.AdminDoctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazeCare.WEB.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminDoctorController : Controller
    {
        private readonly HttpClient _httpClient;

        public AdminDoctorController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // GET: AdminDoctor
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var doctors = await _httpClient.GetFromJsonAsync<List<DoctorResponseViewModel>>("api/v1/doctors");
            return View(doctors);
        }

        // GET: AdminDoctor/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var doctor = await _httpClient.GetFromJsonAsync<DoctorResponseViewModel>($"api/v1/doctors/{id}");
            if (doctor == null) return NotFound();
            return View(doctor);
        }

        // GET: AdminDoctor/Create
        public IActionResult Create() => View();

        // POST: AdminDoctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _httpClient.PostAsJsonAsync("api/v1/doctors", model);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Failed to create doctor.");
            return View(model);
        }

        // GET: AdminDoctor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var doctor = await _httpClient.GetFromJsonAsync<DoctorResponseViewModel>($"api/v1/doctors/{id}");
            if (doctor == null) return NotFound();

            var model = new DoctorUpdateViewModel
            {
                DoctorId = doctor.DoctorId,
                Name = doctor.Name,
                Email = doctor.Email,
                Password = "", // Handle password update as needed
                Specialty = doctor.Specialty,
                Experience = doctor.Experience,
                Qualification = doctor.Qualification,
                Designation = doctor.Designation
            };
            return View(model);
        }

        // POST: AdminDoctor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorUpdateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _httpClient.PutAsJsonAsync($"api/v1/doctors/{model.DoctorId}", model);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Failed to update doctor.");
            return View(model);
        }

        // GET: AdminDoctor/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var doctor = await _httpClient.GetFromJsonAsync<DoctorResponseViewModel>($"api/v1/doctors/{id}");
            if (doctor == null) return NotFound();
            return View(doctor);
        }

        // POST: AdminDoctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _httpClient.DeleteAsync($"api/v1/doctors/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Failed to delete doctor.");
            var doctor = await _httpClient.GetFromJsonAsync<DoctorResponseViewModel>($"api/v1/doctors/{id}");
            return View("Delete", doctor);
        }
    }
}
