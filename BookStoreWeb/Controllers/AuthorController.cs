using BookStoreWeb.Models.Domain;
using BookStoreWeb.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _bookService;

        public AuthorController(IAuthorService service)
        {
            _bookService = service;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _bookService.Add(model);

            if (result)
            {
                TempData["msg"] = "Author added successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Failed to add Author";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            var record = _bookService.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _bookService.Update(model);

            if (result)
            {
                return RedirectToAction(nameof(GetAll));
            }
            TempData["msg"] = "Failed to update Author";

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = _bookService.Delete(id);
            return RedirectToAction("GetAll");

        }

        public IActionResult GetAll()
        {
            var data = _bookService.GetAll();
            return View(data);
        }
    }
}
