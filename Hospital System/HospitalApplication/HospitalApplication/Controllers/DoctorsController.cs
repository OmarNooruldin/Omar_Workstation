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
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController(ApplicationDbContext context)
        {  _context = context; }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DoctorView)]
        public IActionResult Index()
        {
            List<Doctor> doctor = _context.Doctors.Include(d =>d.Department).ToList();
            return View(doctor);
        }

        [Authorize(Policy =PermissionsNames.DoctorDetails)]
        public IActionResult Details(int Id)
        {
            Doctor? doctor = _context.Doctors.Include(d =>d.Department).FirstOrDefault(d =>d.Id == Id);
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
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Doctors.AddAsync(doctor);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            LoadDepartments();
            return View(doctor);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DoctorUpdate)]
        public IActionResult Update(int Id)
        {
            Doctor? doctor = _context.Doctors.Find(Id);
            if (doctor == null)
            {
                return NotFound();
            }
            LoadDepartments();
            return View(doctor);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.DoctorUpdate)]
        public IActionResult Update(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Doctors.Update(doctor);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            LoadDepartments();
            return View(doctor);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DoctorDelete)]
        public IActionResult Delete(int Id)
        {
            Doctor? doctor = _context.Doctors.Find(Id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.DoctorDelete)]
        public IActionResult Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private void LoadDepartments()
        {
            IEnumerable<Department> departments = _context.Departments.ToList();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
        }
    }
}
