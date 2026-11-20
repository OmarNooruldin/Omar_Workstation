using HospitalApplication.Application.Dtos;
using HospitalApplication.Application.Security;
using HospitalApplication.Domain.Models;
using HospitalApplication.Infrastructure.Data;
using HospitalApplication.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApplication.WebDashboard.Controllers

{
    [Authorize]
    public class ElectronicHealthRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IElectronicHealthRecordService _service;

        public ElectronicHealthRecordsController(ApplicationDbContext context, IElectronicHealthRecordService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordView)]
        public IActionResult Index()
        {
            var electronicHealthRecords = _service.GetAllElectronicHealthRecords();
            return View(electronicHealthRecords);
        }

        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordDetails)]
        public IActionResult Details(int Id)
        {
            var electronicHealthRecord = _service.GetElectronicHealthRecordById(Id);
            if (electronicHealthRecord == null)
            {
                return NotFound();
            }
            return View(electronicHealthRecord);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordCreate)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordCreate)]
        public IActionResult Create(ElectronicHealthRecordCreateDto electronicHealthRecord)
        {
            if (ModelState.IsValid)
            {
                _service.CreateElectronicHealthRecord(electronicHealthRecord);
                _service.SaveElectronicHealthRecords();
                return RedirectToAction("Index");
            }
            return View(electronicHealthRecord);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordUpdate)]
        public IActionResult Update(int Id)
        {
            var electronicHealthRecord = _service.GetElectronicHealthRecordById(Id);
            if (electronicHealthRecord == null)
            {
                return NotFound();
            }
            return View(electronicHealthRecord);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordUpdate)]
        public IActionResult Update(ElectronicHealthRecordListDto electronicHealthRecord)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateElectronicHealthRecord(electronicHealthRecord);
                _service.SaveElectronicHealthRecords();
                return RedirectToAction("Index");
            }
            return View(electronicHealthRecord);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordDelete)]
        public IActionResult Delete(int Id)
        {
            var electronicHealthRecord = _service.GetElectronicHealthRecordById(Id);
            if (electronicHealthRecord == null)
            {
                return NotFound();
            }
            return View(electronicHealthRecord);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordDelete)]
        public IActionResult Delete(ElectronicHealthRecord electronicHealthRecord)
        {
            _service.DeleteElectronicHealthRecord(electronicHealthRecord.Id);
            _service.SaveElectronicHealthRecords();
            return RedirectToAction("Index");
        }
    }
}
