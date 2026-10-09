using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitalApplication.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.AppointmentView)]
        public IActionResult Index()
        {
            List<Appointment> appointments = _context.Appointments.Include(a =>a.Patient).ToList();
            return View(appointments);
        }

        [Authorize(Policy =PermissionsNames.AppointmentDetails)]
        public IActionResult Details(int Id)
        {
            Appointment? appointment = _context.Appointments.Include(a =>a.Patient).FirstOrDefault(a=>a.Id == Id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.AppointmentCreate)]
        public IActionResult Create()
        {
            LoadPatient();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.AppointmentCreate)]
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
        [Authorize(Policy =PermissionsNames.AppointmentUpdate)]
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
        [Authorize(Policy =PermissionsNames.AppointmentUpdate)]
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
        [Authorize(Policy =PermissionsNames.AppointmentDelete)]
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
        [Authorize(Policy =PermissionsNames.AppointmentDelete)]
        public IActionResult Delete(Appointment appointment)
        {

                _context.Appointments.Remove(appointment);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
        }

        private void LoadPatient()
        {
            IEnumerable<Patient> patients = _context.Patients.ToList();
            ViewBag.Patients = new SelectList(patients, "Id", "LastName");
        }

        private void LoadDoctor()
        {
            IEnumerable<Doctor> doctors = _context.Doctors.ToList();
            ViewBag.Doctors = new SelectList(doctors, "Id", "LastName");
        }
    }
}
