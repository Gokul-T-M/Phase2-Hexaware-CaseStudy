using AmazeCare.WEB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace AmazeCare.WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public AdminController(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        // GET: /Admin/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Admin/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var apiUrl = $"{_config["ApiBaseUrl"]}api/v1/auth/register/admin";
            var httpClient = _httpClientFactory.CreateClient();

            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Registration successful! Please login.";
                return RedirectToAction("Login");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", error);
                return View(model);
            }
        }

        // GET: /Admin/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Admin/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var apiUrl = $"{_config["ApiBaseUrl"]}api/v1/auth/login";
            var httpClient = _httpClientFactory.CreateClient();

            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiUrl, content);

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", $"Invalid email or password. API Response: {json}");
                return View(model);
            }

            // Extract token from API response
            string token = null;
            try
            {
                var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("token", out var tokenElement))
                    token = tokenElement.GetString();
            }
            catch
            {
                ModelState.AddModelError("", "Invalid response from API.");
                return View(model);
            }

            if (string.IsNullOrEmpty(token))
            {
                ModelState.AddModelError("", "No token returned from API.");
                return View(model);
            }

            // Parse JWT to get claims
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            // Robust role claim extraction
            var roleClaim = jwt.Claims.FirstOrDefault(c =>
                c.Type == ClaimTypes.Role ||
                c.Type == "role" ||
                c.Type == "roles" ||
                c.Type.EndsWith("/role"));

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, jwt.Claims.FirstOrDefault(c => c.Type == "email")?.Value ?? ""),
        new Claim(ClaimTypes.Email, jwt.Claims.FirstOrDefault(c => c.Type == "email")?.Value ?? ""),
        new Claim(ClaimTypes.Role, roleClaim?.Value ?? ""),
        new Claim(ClaimTypes.NameIdentifier, jwt.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value ?? "")
    };

            // Debug: Print out all claims for troubleshooting
            foreach (var claim in claims)
            {
                System.Diagnostics.Debug.WriteLine($"Cookie Claim: {claim.Type} = {claim.Value}");
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // Store JWT in session for future API calls
            HttpContext.Session.SetString("JWToken", token);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Dashboard");
        }


        // GET: /Admin/Dashboard
        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard()
        {
            ViewBag.AdminName = User.Identity.Name;
            return View();
        }

        // GET: /Admin/Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("JWToken");
            return RedirectToAction("Login");
        }
    }
}
