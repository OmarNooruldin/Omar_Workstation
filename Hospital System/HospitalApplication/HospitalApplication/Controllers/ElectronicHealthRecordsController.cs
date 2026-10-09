using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApplication.Controllers
{
    [Authorize]
    public class ElectronicHealthRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ElectronicHealthRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordView)]
        public IActionResult Index()
        {
            List<ElectronicHealthRecord> electronicHealthRecords = _context.ElectronicHealthRecords.ToList();
            return View(electronicHealthRecords);
        }

        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordDetails)]
        public IActionResult Details(int Id)
        {
            ElectronicHealthRecord? electronicHealthRecord = _context.ElectronicHealthRecords.Find(Id);
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
        public IActionResult Create(ElectronicHealthRecord electronicHealthRecord)
        {
            if (ModelState.IsValid)
            {
                _context.ElectronicHealthRecords.AddAsync(electronicHealthRecord);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(electronicHealthRecord);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordUpdate)]
        public IActionResult Update(int Id)
        {
            ElectronicHealthRecord? electronicHealthRecord = _context.ElectronicHealthRecords.Find(Id);
            if (electronicHealthRecord == null)
            {
                return NotFound();
            }
            return View(electronicHealthRecord);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordUpdate)]
        public IActionResult Update(ElectronicHealthRecord electronicHealthRecord)
        {
            if (ModelState.IsValid)
            {
                _context.ElectronicHealthRecords.Update(electronicHealthRecord);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(electronicHealthRecord);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.ElectronicHealthRecordDelete)]
        public IActionResult Delete(int Id)
        {
            ElectronicHealthRecord? electronicHealthRecord = _context.ElectronicHealthRecords.Find(Id);
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
            _context.ElectronicHealthRecords.Remove(electronicHealthRecord);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
