using HospitalApplication.Data;
using HospitalApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApplication.Controllers
{
    public class StaffsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffsController(ApplicationDbContext context)
        {  _context = context; }

        public IActionResult Index()
        {
            List<Staff> staff = _context.Staffs.ToList();
            return View(staff);
        }

        public IActionResult Details(int Id)
        {
            Staff? staff = _context.Staffs.Find(Id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Staffs.AddAsync(staff);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Staff? staff = _context.Staffs.Find(Id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        [HttpPost]
        public IActionResult Update(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Staffs.Update(staff);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Staff? staff = _context.Staffs.Find(Id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        [HttpPost]
        public IActionResult Delete(Staff staff)
        {
            _context.Staffs.Remove(staff);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
