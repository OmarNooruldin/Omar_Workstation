using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using MyProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomersDbContext _context;

        public CustomersController(CustomersDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Customers> customers = _context.customers.ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                _context.customers.Add(customers);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }
    }
}
