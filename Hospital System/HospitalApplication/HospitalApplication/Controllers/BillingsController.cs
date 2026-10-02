using HospitalApplication.Data;
using HospitalApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApplication.Controllers
{
    public class BillingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BillingsController(ApplicationDbContext context)
        { _context = context; }

        public IActionResult Index()
        {
            List<Billing> billings = _context.Billings.ToList();
            return View(billings);
        }

        public IActionResult Details(int Id)
        {
            Billing? billing = _context.Billings.Find(Id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Billing billing)
        {
            if (ModelState.IsValid)
            {
                _context.Billings.AddAsync(billing);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(billing);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Billing? billing = _context.Billings.Find(Id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        [HttpPost]
        public IActionResult Update(Billing billing)
        {
            if (ModelState.IsValid)
            {
                _context.Billings.Update(billing);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(billing);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Billing? billing = _context.Billings.Find(Id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        [HttpPost]
        public IActionResult Delete(Billing billing)
        {
            _context.Billings.Remove(billing);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
