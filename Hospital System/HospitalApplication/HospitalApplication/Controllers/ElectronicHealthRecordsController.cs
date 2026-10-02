using HospitalApplication.Data;
using HospitalApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApplication.Controllers
{
    public class ElectronicHealthRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ElectronicHealthRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ElectronicHealthRecord> electronicHealthRecords = _context.ElectronicHealthRecords.ToList();
            return View(electronicHealthRecords);
        }

        public IActionResult Details(int Id)
        {
            ElectronicHealthRecord? electronicHealthRecord = _context.ElectronicHealthRecords.Find(Id);
            if (electronicHealthRecord == null)
            {
                return NotFound();
            }
            return View(electronicHealthRecord);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ElectronicHealthRecord electronicHealthRecord)
        {
            if (ModelState.IsValid)
            {
                _context.ElectronicHealthRecords.AddAsync(electronicHealthRecord);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(electronicHealthRecord);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            ElectronicHealthRecord? electronicHealthRecord = _context.ElectronicHealthRecords.Find(Id);
            if (electronicHealthRecord == null)
            {
                return NotFound();
            }
            return View(electronicHealthRecord);
        }

        [HttpPost]
        public IActionResult Update(ElectronicHealthRecord electronicHealthRecord)
        {
            if (ModelState.IsValid)
            {
                _context.ElectronicHealthRecords.Update(electronicHealthRecord);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(electronicHealthRecord);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            ElectronicHealthRecord? electronicHealthRecord = _context.ElectronicHealthRecords.Find(Id);
            if (electronicHealthRecord == null)
            {
                return NotFound();
            }
            return View(electronicHealthRecord);
        }

        [HttpPost]
        public IActionResult Delete(ElectronicHealthRecord electronicHealthRecord)
        {
            _context.ElectronicHealthRecords.Remove(electronicHealthRecord);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
