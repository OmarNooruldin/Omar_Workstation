using HospitalApplication.Application.Dtos;
using HospitalApplication.Application.Security;
using HospitalApplication.Infrastructure.Data;
using HospitalApplication.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.WebDashboard.Controllers

{
    [Authorize]
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDoctorService _doctorservice;

        public DoctorsController(ApplicationDbContext context, IDoctorService doctorService)
        {
            _context = context;
            _doctorservice = doctorService;
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DoctorView)]
        public IActionResult Index()
        {
            var doctor = _doctorservice.GetAllDoctors();
            return View(doctor);
        }

        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            List<DoctorListDto> doctors = _context.Doctors.Select(d => new DoctorListDto
            {
                FirstName = d.FirstName,
                LastName = d.LastName,
                LicenseNumber = d.LicenseNumber,
                Speciality = d.Speciality,
                ConsultationFee = d.ConsultationFee,
                DepartmentName = d.DepartmentId}).ToList();
            return Ok(doctors);
        }

        [Authorize(Policy =PermissionsNames.DoctorDetails)]
        public IActionResult Details(int Id)
        {
            var doctor = _doctorservice.GetDoctorById(Id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DoctorCreate)]
        public IActionResult Create()
        {
            LoadDepartments();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.DoctorCreate)]
        public IActionResult Create(DoctorCreateDto doctor)
        {
            if (ModelState.IsValid)
            {
                _doctorservice.CreateDoctor(doctor);
                _doctorservice.SaveDoctors();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DoctorUpdate)]
        public IActionResult Update(int Id)
        {
            var doctor = _doctorservice.GetDoctorById(Id);
            if (doctor == null)
            {
                return NotFound();
            }
            LoadDepartments();
            return View(doctor);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.DoctorUpdate)]
        public IActionResult Update(DoctorListDto doctor)
        {
            if (ModelState.IsValid)
            {
                _doctorservice.UpdateDoctor(doctor);
                _doctorservice.SaveDoctors();
                return RedirectToAction("Index");
            }
            LoadDepartments();
            return View(doctor);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DoctorDelete)]
        public IActionResult Delete(int Id)
        {
            var doctor = _doctorservice.GetDoctorById(Id);
            if (doctor == null)
            {
                return NotFound();
            }
            LoadDepartments();
            return View(doctor);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.DoctorDelete)]
        public IActionResult Delete(DoctorListDto doctor)
        {
            _doctorservice.DeleteDoctor(doctor.Id);
            _doctorservice.SaveDoctors();
            return RedirectToAction("Index");
        }

        private void LoadDepartments()
        {
            var departments = _doctorservice.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
        }
    }
}
