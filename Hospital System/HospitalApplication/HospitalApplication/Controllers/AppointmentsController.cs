using HospitalApplication.Data;
using HospitalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitalApplication.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Appointment> appointments = _context.Appointments.Include(a => a.Patient).ToList();
            return View(appointments);
        }

        public IActionResult Details(int Id)
        {
            Appointment? appointment = _context.Appointments.Find(Id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadPatient();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.AddAsync(appointment);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            LoadPatient();
            return View(appointment);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Appointment? appointment = _context.Appointments.Find(Id);
            if (appointment == null)
            {
                return NotFound();
            }
            LoadPatient();
            return View(appointment);
        }

        [HttpPost]
        public IActionResult Update(Appointment appointment)
        {
            if (ModelState.IsValid) 
            {
                _context.Appointments.Update(appointment);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            LoadPatient();
            return View(appointment);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Appointment? appointment = _context.Appointments.Find(Id);
            if (appointment == null)
            {
                return NotFound();
            }
            LoadPatient();
            return View(appointment);
        }

        [HttpPost]
        public IActionResult Delete(Appointment appointment)
        {

                _context.Appointments.Remove(appointment);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
        }

        private void LoadPatient()
        {
            IEnumerable<Patient> patients = _context.Patients.ToList();
            ViewBag.Patients = new SelectList(patients, "Id", "Name");
        }

        private void LoadStaff()
        {
            IEnumerable<Staff> staff = _context.Staffs.ToList();
            ViewBag.Staffs = new SelectList(staff, "Id", "Name");
        }
    }
}
