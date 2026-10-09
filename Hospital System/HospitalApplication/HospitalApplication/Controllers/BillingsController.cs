using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalApplication.Controllers
{
    [Authorize]
    public class BillingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BillingsController(ApplicationDbContext context)
        { _context = context; }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.BillingView)]
        public IActionResult Index()
        {
            List<Billing> billings = _context.Billings.ToList();
            return View(billings);
        }

        [Authorize(Policy =PermissionsNames.BillingDetails)]
        public IActionResult Details(int Id)
        {
            Billing? billing = _context.Billings.Find(Id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.BillingCreate)]
        public IActionResult Create()
        {
            LoadAppointment();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        [Authorize(Policy =PermissionsNames.BillingCreate)]
        public IActionResult Create(Billing billing)
        {
            if (ModelState.IsValid)
            {
                _context.Billings.AddAsync(billing);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            LoadAppointment();
            return View(billing);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.BillingUpdate)]
        public IActionResult Update(int Id)
        {
            Billing? billing = _context.Billings.Find(Id);
            if (billing == null)
            {
                return NotFound();
            }
            LoadAppointment();
            return View(billing);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.BillingUpdate)]
        public IActionResult Update(Billing billing)
        {
            if (ModelState.IsValid)
            {
                _context.Billings.Update(billing);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            LoadAppointment();
            return View(billing);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.BillingDelete)]
        public IActionResult Delete(int Id)
        {
            Billing? billing = _context.Billings.Find(Id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.BillingDelete)]
        public IActionResult Delete(Billing billing)
        {
            _context.Billings.Remove(billing);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private void LoadAppointment()
        {
            IEnumerable<Appointment> appointments = _context.Appointments.ToList();
            ViewBag.Appointments = new SelectList(appointments, "Id", "AppointmentDate");
        }
    }
}
