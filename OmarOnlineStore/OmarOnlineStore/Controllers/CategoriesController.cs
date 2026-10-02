using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmarOnlineStore.Data;
using OmarOnlineStore.Models;

namespace OmarOnlineStore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Category? category = _context.Categories.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Category? category = _context.Categories.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Category? category = _context.Categories.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
