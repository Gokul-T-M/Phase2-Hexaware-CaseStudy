using ClientDirectoryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientDirectoryApp.Controllers
{
    [Route("client")]
    public class ClientController : Controller
    {
        static List<ClientInfo> clients = new List<ClientInfo>();

        [Route("all")]
        public IActionResult ShowAllClientDetails()
        {
            return View(clients);
        }


        [Route("id/{id}")]
        public IActionResult GetDetailsByClientId(int id)
        {
            var client = clients.FirstOrDefault(c => c.ClientId == id);
            return View("ClientDetails",client);
        }


        [Route("name/{name}")]
        public IActionResult GetDetailsByCompanyName(string name)
        {
            var client = clients.FirstOrDefault(c => c.CompanyName == name);
            return View("ClientDetails", client);
        }

        [Route("email/{email}")]
        public IActionResult GetDetailsByEmailId(string email)
        {
            var client = clients.FirstOrDefault(c => c.Email == email);
            return View("ClientDetails",client);
        }


        [Route("category/{category}")]
        public IActionResult GetDetailsByCategory(string category)
        {
            var filtered = clients.Where(c => c.Category == category).ToList();
            return View("ShowAllClientDetails", filtered);
        }


        [Route("standard/{standard}")]
        public IActionResult GetDetailsByStandard(string standard)
        {
            var filtered = clients.Where(c => c.Standard == standard).ToList();
            return View("ShowAllClientDetails", filtered);
        }

        [Route("add")]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddClient(ClientInfo clientInfo)
        {

            Console.WriteLine($"ID: {clientInfo.ClientId}, Name: {clientInfo.CompanyName}, Email: {clientInfo.Email}");
            clients.Add(clientInfo);

            return RedirectToAction("ShowAllClientDetails");
        }
    }
}
