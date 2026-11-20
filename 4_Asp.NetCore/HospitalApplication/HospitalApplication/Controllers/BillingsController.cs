using HospitalApplication.Data;
using HospitalApplication.Dtos;
using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;
using HospitalApplication.Repositories.Billings;
using HospitalApplication.Security;
using HospitalApplication.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalApplication.Controllers
{
    [Authorize]
    public class BillingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBillingService _billingService;

        public BillingsController(ApplicationDbContext context, IBillingService billingService)
        { 
            _context = context;
            _billingService = billingService;
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.BillingView)]
        public IActionResult Index()
        {
            var billings = _billingService.GetAllBills();
            return View(billings);
        }

        [HttpGet]
        public IActionResult GetAllBillings()
        {
            List<BillingListDto> billings = _context.Billings.Select(b => new BillingListDto
            {
                TotalAmount = b.TotalAmount,
                InsuranceProvider = b.InsuranceProvider,
                AppointmentId = b.Appointment.Id}).ToList();
            return Ok(billings);
        }

        [Authorize(Policy =PermissionsNames.BillingDetails)]
        public IActionResult Details(int Id)
        {
            var billing = _billingService.GetBillById(Id);
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
        public IActionResult Create(BillingCreateDto billing)
        {
            if (ModelState.IsValid)
            {
                _billingService.CreateBill(billing);
                _billingService.SaveBill();
                return RedirectToAction("Index");
            }
            return View(billing);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.BillingUpdate)]
        public IActionResult Update(int Id)
        {
            var billing = _billingService.GetBillById(Id);
            if (billing == null)
            {
                return NotFound();
            }
            LoadAppointment();
            return View(billing);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.BillingUpdate)]
        public IActionResult Update(BillingListDto billing)
        {
            if (ModelState.IsValid)
            {
                _billingService.UpdateBill(billing);
                _billingService.SaveBill();
                return RedirectToAction("Index");
            }
            LoadAppointment();
            return View(billing);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.BillingDelete)]
        public IActionResult Delete(int Id)
        {
            var billing = _billingService.GetBillById(Id);
            if (billing == null)
            {
                return NotFound();
            }
            LoadAppointment();
            return View(billing);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.BillingDelete)]
        public IActionResult Delete(Billing billing)
        {
            _billingService.DeleteBill(billing.Id);
            _billingService.SaveBill();
            return RedirectToAction("Index");
        }

        private void LoadAppointment()
        {
            var appointments = _billingService.GetAllAppointments();
            ViewBag.Appointments = new SelectList(appointments, "Id", "Id");
        }
    }
}
