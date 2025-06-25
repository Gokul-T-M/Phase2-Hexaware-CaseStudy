using BookValidationApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookValidationApp.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>();

        public IActionResult Index()
        {
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            // Check uniqueness
            if (books.Any(b => b.Isbn == book.Isbn))
            {
                ModelState.AddModelError("Isbn", "ISBN must be unique");
            }

            if (ModelState.IsValid)
            {
                books.Add(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }
    }
}
