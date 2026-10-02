using Microsoft.AspNetCore.Mvc;
using OmarOnlineStore.Data;
using OmarOnlineStore.Models;

namespace OmarOnlineStore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers = _context.Customers.ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Customer? customer = _context.Customers.Find(Id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Customer? customer  = _context.Customers.Find(Id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Customer? customer = _context.Customers.Find(Id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
