using LibraryApp.Models;
using LibraryApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repo;

        public BookController(IBookRepository repo)
        {
            _repo = repo;
        }

        public IActionResult List()
        {
            var books = _repo.GetAllBooks();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _repo.GetBookById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            _repo.AddBook(book);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Delete(int id)
        {
            var book = _repo.GetBookById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteBook(id);
            return RedirectToAction(nameof(List));
        }
    }
}
