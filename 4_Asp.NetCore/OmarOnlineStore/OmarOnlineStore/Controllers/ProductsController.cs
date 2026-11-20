using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OmarOnlineStore.Data;
using OmarOnlineStore.Models;

namespace OmarOnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context ;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _context.Products.Include(p=>p.Category).ToList();
            return View(products);
        }

        public IActionResult Details(int Id)
        {
            Product? product = _context.Products.Include(p => p.Category).FirstOrDefault(e=>e.Id==Id);
                if (product == null) 
                {
                return NotFound();
                }
                return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            LoadCategories();
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Product? product = _context.Products.Find(Id);
            if (product == null)
            {
                return NotFound();
            }
            LoadCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            LoadCategories();
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Product? product = _context.Products.Find(Id);
            if (product == null)
            {
                return NotFound();
            }
            LoadCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private void LoadCategories()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories,"Id","Name");
        }
    }
}
