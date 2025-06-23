using ContactsDirectoryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsDirectoryApp.Controllers
{
    public class ContactController : Controller
    {
        static List<ContactInfo> contacts = new List<ContactInfo>();

        public IActionResult ShowContacts()
        {
            return View(contacts);
        }

        public IActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            contacts.Add(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}
