using HospitalApp.Dtos;
using HospitalApp.Security;
using HospitalApp.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DepartmentView)]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        [Authorize(Policy =PermissionsNames.DepartmentDetails)]
        public IActionResult Details(int Id)
        {
            var department = _departmentService.GetDepartmentById(Id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DepartmentCreate)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.DepartmentCreate)]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentCreateDto department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.CreateDepartment(department);
                _departmentService.SaveDepartments();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DepartmentUpdate)]
        public IActionResult Update(int Id)
        {
            var department = _departmentService.GetDepartmentById(Id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.DepartmentUpdate)]
        public IActionResult Update(DepartmentUpdateDto department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.UpdateDepartment(department);
                _departmentService.SaveDepartments();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DepartmentDelete)]
        public IActionResult Delete(int Id)
        {
            var department = _departmentService.GetDepartmentById(Id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.DepartmentDelete)]
        public IActionResult Delete(DepartmentUpdateDto department)
        {

            _departmentService.DeleteDepartment(department.Id);
            _departmentService.SaveDepartments();
            return RedirectToAction("Index");
        }
    }
}
