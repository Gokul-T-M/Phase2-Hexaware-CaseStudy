using AmazeCare.WEB.Models.AdminAppointment;
using Microsoft.AspNetCore.Mvc;

namespace AmazeCare.WEB.Controllers
{
    public class AdminAppointmentController : Controller
    {
        private readonly HttpClient _httpClient;
        //private const string ApiVersion = "v1";

        public AdminAppointmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // GET: Appointment
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var appointments = await _httpClient.GetFromJsonAsync<List<AppointmentResponseViewModel>>("api/v1/appointments");
            return View(appointments);
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var appointment = await _httpClient.GetFromJsonAsync<AppointmentResponseViewModel>($"api/v1/appointments/{id}");
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        // GET: Appointment/Delete/5 (confirmation)
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var appointment = await _httpClient.GetFromJsonAsync<AppointmentResponseViewModel>($"api/v1/appointments/{id}");
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _httpClient.DeleteAsync($"api/v1/appointments/{id}");
            return RedirectToAction(nameof(Index));
        }

        // GET: Appointment/ByDoctor
        public IActionResult ByDoctor()
        {
            return View();
        }

        // POST: Appointment/ByDoctor
        [HttpPost]
        public async Task<IActionResult> ByDoctor(int doctorId)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var appointments = await _httpClient.GetFromJsonAsync<List<AppointmentResponseViewModel>>($"api/v1/appointments/doctor/{doctorId}");
            ViewBag.DoctorId = doctorId;
            return View("ByDoctorResults", appointments);
        }

        // GET: Appointment/ByPatient
        public IActionResult ByPatient()
        {
            return View();
        }

        // POST: Appointment/ByPatient
        [HttpPost]
        public async Task<IActionResult> ByPatient(int patientId)
        {

            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var appointments = await _httpClient.GetFromJsonAsync<List<AppointmentResponseViewModel>>($"api/v1/appointments/patient/{patientId}");
            ViewBag.PatientId = patientId;
            return View("ByPatientResults", appointments);
        }


    }
}
