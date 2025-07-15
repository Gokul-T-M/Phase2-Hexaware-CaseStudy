using AmazeCare.WEB.Models.AdminPatient;
using Microsoft.AspNetCore.Mvc;

namespace AmazeCare.WEB.Controllers
{
    public class AdminPatientController : Controller
    {
        private readonly HttpClient _httpClient;

        public AdminPatientController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // GET: Patient
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var patients = await _httpClient.GetFromJsonAsync<List<PatientResponseViewModel>>("api/v1/patients");
            return View(patients);
        }

        // GET: Patient/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var patient = await _httpClient.GetFromJsonAsync<PatientResponseViewModel>($"api/v1/patients/{id}");
            if (patient == null) return NotFound();
            return View(patient);
        }


        // GET: Patient/Create
        public IActionResult Create() => View();

        // POST: Patient/Create
        [HttpPost]
        public async Task<IActionResult> Create(PatientCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var response = await _httpClient.PostAsJsonAsync("api/v1/patients", model);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Failed to create patient.");
            return View(model);
        }

        // GET: Patient/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var patient = await _httpClient.GetFromJsonAsync<PatientResponseViewModel>($"api/v1/patients/{id}");
            if (patient == null) return NotFound();

            var updatedPatient = new PatientUpdateViewModel
            {
                PatientId = patient.PatientId,
                Name = patient.Name,
                Email = patient.Email,
                Password = "",
                ContactNumber = patient.ContactNumber,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                PreviousMedicalRecords = patient.PreviousMedicalRecords
            };

            return View(updatedPatient);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(PatientUpdateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _httpClient.PutAsJsonAsync($"api/v1/patients/{model.PatientId}", model);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            
            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError("", $"Failed to update patient. API says: {error}");
            return View(model);
   
        }

        // GET: Patient/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var patient = await _httpClient.GetFromJsonAsync<PatientResponseViewModel>($"api/v1/patients/{id}");
            if (patient == null) return NotFound();
            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _httpClient.DeleteAsync($"api/v1/patients/{id}");
            return RedirectToAction(nameof(Index));
        }


    }
}
