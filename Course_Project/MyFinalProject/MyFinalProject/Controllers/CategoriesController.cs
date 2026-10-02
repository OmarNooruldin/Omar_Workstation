using Microsoft.AspNetCore.Mvc;
using MyFinalProject.Data;
using MyFinalProject.Models;


namespace MyFinalProject.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // New Code for Employees action methods

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Category? cat = _context.Categories.Find(Id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(cat);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            Category? cat = _context.Categories.Find(Id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost]
        public IActionResult Update(Category cat)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(cat);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Category? cat = _context.Categories.Find(Id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Category cat)
        {

            _context.Categories.Remove(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
