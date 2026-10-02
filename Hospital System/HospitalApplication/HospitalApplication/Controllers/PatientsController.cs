using HospitalApplication.Data;
using HospitalApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApplication.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {  _context = context; }

        public IActionResult Index()
        {
            List<Patient> patients = _context.Patients.ToList();
            return View(patients);
        }

        public IActionResult Details(int Id)
        {
            Patient? patient = _context.Patients.Find(Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Patients.AddAsync(patient);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Patient? patient = _context.Patients.Find(Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        public IActionResult Update(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Patients.Update(patient);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Patient? patient = _context.Patients.Find(Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        public IActionResult Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
