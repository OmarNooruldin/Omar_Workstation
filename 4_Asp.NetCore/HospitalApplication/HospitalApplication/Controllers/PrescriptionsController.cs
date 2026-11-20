using HospitalApplication.Data;
using HospitalApplication.Dtos;
using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;
using HospitalApplication.Repositories.Prescriptions;
using HospitalApplication.Security;
using HospitalApplication.Service.Base;
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
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(ApplicationDbContext context, IPrescriptionService prescriptionService)
        {
            _context = context; 
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PrescriptionView)]
        public IActionResult Index()
        {
            var prescriptions  = _prescriptionService.GetAllPrescriptions();
            return View(prescriptions);
        }

        [HttpGet]
        public IActionResult GetAllPrescriptions()
        {
            List<PrescriptionListDto> prescriptions = _context.Prescriptions.Select(p => new PrescriptionListDto
            {
                MedicineName = p.MedicineName,
                Dosage = p.Dosage,
                DurationDays = p.DurationDays,
                Frequency = p.Frequency,
                ElectronicHealthRecordId = p.ElectronicHealthRecordId
            }).ToList();
            return Ok(prescriptions);
        }

        [Authorize(Policy =PermissionsNames.PrescriptionDetails)]
        public IActionResult Details(int Id)
        {
            var prescription = _prescriptionService.GetPrescriptionById(Id);
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
        public IActionResult Create(PrescriptionCreateDto prescription)
        {
            if (ModelState.IsValid)
            {
                _prescriptionService.CreatePrescription(prescription);
                _prescriptionService.SavePrescriptions();
                return RedirectToAction("Index");
            }
            return View(prescription);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PrescriptionUpdate)]
        public IActionResult Update(int Id)
        {
            var prescription = _prescriptionService.GetPrescriptionById(Id);
            if (prescription == null)
            {
                return NotFound();
            }
            LoadElectronicHealthRecords();
            return View(prescription);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.PrescriptionUpdate)]
        public IActionResult Update(PrescriptionListDto prescription)
        {
            if (ModelState.IsValid)
            {
                _prescriptionService.UpdatePrescription(prescription);
                _prescriptionService.SavePrescriptions();
                return RedirectToAction("Index");
            }
            LoadElectronicHealthRecords();
            return View(prescription);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PrescriptionDelete)]
        public IActionResult Delete(int Id)
        {
            var prescription = _prescriptionService.GetPrescriptionById(Id);
            if (prescription == null)
            {
                return NotFound();
            }
            LoadElectronicHealthRecords();
            return View(prescription);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.PrescriptionDelete)]
        public IActionResult Delete(PrescriptionListDto prescription)
        {
            _prescriptionService.DeletePrescription(prescription.Id);
            _prescriptionService.SavePrescriptions();
            return RedirectToAction("Index");
        }

        private void LoadElectronicHealthRecords()
        {
            var electronicHealthRecords = _prescriptionService.GetAllEHRs();
            ViewBag.ElectronicHealthRecord = new SelectList(electronicHealthRecords, "Id", "Diagnosis");
        }
    }
}
