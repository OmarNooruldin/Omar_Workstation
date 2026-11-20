using HospitalApp.Data;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Security;
using HospitalApp.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalApp.Controllers
{
    public class NursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INurseService _nurseservice;

        public NursesController(ApplicationDbContext context, INurseService nurseService)
        {
            _context = context;
            _nurseservice = nurseService;
        }

        [HttpGet]
        [Authorize(Policy = PermissionsNames.NurseView)]
        public IActionResult Index()
        {
            var nurses = _nurseservice.GetAllNurses();
            return View(nurses);
        }


        [Authorize(Policy = PermissionsNames.NurseDetails)]
        public IActionResult Details(int Id)
        {
            var nurse = _nurseservice.GetNurseById(Id);
            if (nurse == null)
            {
                return NotFound();
            }
            return View(nurse);
        }

        [HttpGet]
        [Authorize(Policy = PermissionsNames.NurseCreate)]
        public IActionResult Create()
        {
            LoadDepartments();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = PermissionsNames.NurseCreate)]
        public IActionResult Create(NurseCreateDto nurse)
        {
            if (ModelState.IsValid)
            {
                _nurseservice.CreateNurse(nurse);
                _nurseservice.SaveNurses();
                return RedirectToAction("Index");
            }
            return View(nurse);
        }

        [HttpGet]
        [Authorize(Policy = PermissionsNames.NurseUpdate)]
        public IActionResult Update(int Id)
        {
            var nurse = _nurseservice.GetNurseById(Id);
            if (nurse == null)
            {
                return NotFound();
            }
            LoadDepartments();
            return View(nurse);
        }

        [HttpPost]
        [Authorize(Policy = PermissionsNames.NurseUpdate)]
        public IActionResult Update(NurseUpdateDto nurse)
        {
            if (ModelState.IsValid)
            {
                _nurseservice.UpdateNurse(nurse);
                _nurseservice.SaveNurses();
                return RedirectToAction("Index");
            }
            LoadDepartments();
            return View(nurse);
        }

        [HttpGet]
        [Authorize(Policy = PermissionsNames.NurseDelete)]
        public IActionResult Delete(int Id)
        {
            var nurse = _nurseservice.GetNurseById(Id);
            if (nurse == null)
            {
                return NotFound();
            }
            LoadDepartments();
            return View(nurse);
        }

        [HttpPost]
        [Authorize(Policy = PermissionsNames.NurseDelete)]
        public IActionResult Delete(Nurse nurse)
        {
            _nurseservice.DeleteNurse(nurse.Id);
            _nurseservice.SaveNurses();
            return RedirectToAction("Index");
        }

        private void LoadDepartments()
        {
            var departments = _nurseservice.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
        }
    }
}
