using HospitalApp.Data;
using HospitalApp.Dtos;
using HospitalApp.Security;
using HospitalApp.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPatientService _patientService;

        public PatientsController(ApplicationDbContext context, IPatientService patientService)
        { 
            _context = context; 
            _patientService = patientService;
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PatientView)]
        public IActionResult Index()
        {
            var patients = _patientService.GetAllPatients();
            return View(patients);
        }

        [Authorize(Policy =PermissionsNames.PatientDetails)]
        public IActionResult Details(int Id)
        {
            var patient = _patientService.GetPatientById(Id);
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
        public IActionResult Create(PatientCreateDto patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.CreatePatient(patient);
                _patientService.SavePatients();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PatientUpdate)]
        public IActionResult Update(int Id)
        {
            var patient = _patientService.GetPatientById(Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.PatientUpdate)]
        public IActionResult Update(PatientListDto pat)
        {
            if (ModelState.IsValid)
            {
                _patientService.UpdatePatient(pat);
                _patientService.SavePatients();
                return RedirectToAction("Index");
            }
            return View(pat);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PatientDelete)]
        public IActionResult Delete(int Id)
        {
            var patient = _patientService.GetPatientById(Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.PatientDelete)]
        public IActionResult Delete(PatientListDto patient)
        {
            _patientService.DeletePatient(patient);
            _patientService.SavePatients();
            return RedirectToAction("Index");
        }
    }
}
