using HospitalApp.Data;
using HospitalApp.Dtos;
using HospitalApp.Security;
using HospitalApp.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitalApp.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(ApplicationDbContext context,IAppointmentService appointmentService) 
        {
            _context = context;
            _appointmentService = appointmentService;
        }

        [HttpGet]
        //[Authorize(Policy =PermissionsNames.AppointmentView)]
        public IActionResult Index()
        {
            var appointments = _appointmentService.GetAllAppointments();
            return View(appointments);
        }

        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            List<AppointmentListDto> appointments = _context.Appointments.Select(a=>new AppointmentListDto
                {
                  AppointmentDate = a.AppointmentDate,
                  ReasonForVisit = a.ReasonForVisit,
                  Status = a.Status,
                  PatientLastName = a.Patient.LastName,
                  DoctorLastName = a.Doctor.LastName}).ToList();
                  return Ok(appointments);
        }

        [Authorize(Policy =PermissionsNames.AppointmentDetails)]
        public IActionResult Details(int Id)
        {
            var appointment = _appointmentService.GetAppointmentById(Id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpGet]
        //[Authorize(Policy =PermissionsNames.AppointmentCreate)]
        public IActionResult Create()
        {
            LoadDoctor();
            LoadPatient();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy =PermissionsNames.AppointmentCreate)]
        public IActionResult Create(AppointmentCreateDto appointment)
        {
            if (ModelState.IsValid)
            {
                _appointmentService.CreateAppointment(appointment);
                _appointmentService.SaveAppointments();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.AppointmentUpdate)]
        public IActionResult Update(int Id)
        {
            var appointment = _appointmentService.GetAppointmentById(Id);
            if (appointment == null)
            {
                return NotFound();
            }
            LoadPatient();
            LoadDoctor();
            return View(appointment);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.AppointmentUpdate)]
        public IActionResult Update(AppointmentUpdateDto appointment)
        {
            if (ModelState.IsValid) 
            {
                _appointmentService.UpdateAppointment(appointment);
                _appointmentService.SaveAppointments();
                return RedirectToAction("Index");
            }
            LoadPatient();
            LoadDoctor();
            return View(appointment);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.AppointmentDelete)]
        public IActionResult Delete(int Id)
        {
            var appointment = _appointmentService.GetAppointmentById(Id);
            if (appointment == null)
            {
                return NotFound();
            }
            LoadPatient();
            LoadDoctor();
            return View(appointment);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.AppointmentDelete)]
        public IActionResult Delete(AppointmentListDto appointment)
        {
            _appointmentService.DeleteAppointment(appointment.Id);
            _appointmentService.SaveAppointments();
            return RedirectToAction("Index");
        }

        private void LoadPatient()
        {
            var patients = _appointmentService.GetAllPatients();
            ViewBag.Patients = patients ;
        }

        private void LoadDoctor()
        {
            var doctors = _appointmentService.GetAllDoctors();
            ViewBag.Doctors = new SelectList(doctors, "Id", "LastName");
        }
    }
}
