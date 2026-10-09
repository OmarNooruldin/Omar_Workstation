using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Controllers
{
    [Authorize]
    public class PrescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionsController(ApplicationDbContext context)
        { _context = context; }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PrescriptionView)]
        public IActionResult Index()
        {
            List<Prescription> prescriptions  = _context.Prescriptions.Include(d => d.ElectronicHealthRecord).ToList();
            return View(prescriptions);
        }

        [Authorize(Policy =PermissionsNames.PrescriptionDetails)]
        public IActionResult Details(int Id)
        {
            Prescription? prescription = _context.Prescriptions.Include(d => d.ElectronicHealthRecord).FirstOrDefault(d => d.Id == Id);
            if (prescription == null)
            {
                return NotFound();
            }
            return View(prescription);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PrescriptionCreate)]
        public IActionResult Create()
        {
            LoadElectronicHealthRecords();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.PrescriptionCreate)]
        public IActionResult Create(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Prescriptions.Add(prescription);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            LoadElectronicHealthRecords();
            return View(prescription);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PrescriptionUpdate)]
        public IActionResult Update(int Id)
        {
            Prescription? prescription = _context.Prescriptions.Find(Id);
            if (prescription == null)
            {
                return NotFound();
            }
            LoadElectronicHealthRecords();
            return View(prescription);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.PrescriptionUpdate)]
        public IActionResult Update(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Prescriptions.Update(prescription);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            LoadElectronicHealthRecords();
            return View(prescription);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PrescriptionDelete)]
        public IActionResult Delete(int Id)
        {
            Prescription? prescription = _context.Prescriptions.Find(Id);
            if (prescription == null)
            {
                return NotFound();
            }
            return View(prescription);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.PrescriptionDelete)]
        public IActionResult Delete(Prescription prescription)
        {
            _context.Prescriptions.Remove(prescription);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private void LoadElectronicHealthRecords()
        {
            IEnumerable<ElectronicHealthRecord> electronicHealthRecords = _context.ElectronicHealthRecords.ToList();
            ViewBag.ElectronicHealthRecord = new SelectList(electronicHealthRecords, "Id", "Diagnosis");
        }
    }
}
