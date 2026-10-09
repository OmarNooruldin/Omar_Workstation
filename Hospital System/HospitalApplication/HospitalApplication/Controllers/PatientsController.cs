using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApplication.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {  _context = context; }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PatientView)]
        public IActionResult Index()
        {
            List<Patient> patients = _context.Patients.ToList();
            return View(patients);
        }

        [Authorize(Policy =PermissionsNames.PatientDetails)]
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
        [Authorize(Policy =PermissionsNames.PatientCreate)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.PatientCreate)]
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
        [Authorize(Policy =PermissionsNames.PatientUpdate)]
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
        [Authorize(Policy =PermissionsNames.PatientUpdate)]
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
        [Authorize(Policy =PermissionsNames.PatientDelete)]
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
        [Authorize(Policy =PermissionsNames.PatientDelete)]
        public IActionResult Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
