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
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DepartmentView)]
        public IActionResult Index()
        {
            List<Department> departments = _context.Departments.ToList();
            return View(departments);
        }

        [Authorize(Policy =PermissionsNames.DepartmentDetails)]
        public IActionResult Details(int Id)
        {
            Department? department = _context.Departments.Find(Id);
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
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.AddAsync(department);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DepartmentUpdate)]
        public IActionResult Update(int Id)
        {
            Department? department = _context.Departments.Find(Id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.DepartmentUpdate)]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.DepartmentDelete)]
        public IActionResult Delete(int Id)
        {
            Department? department = _context.Departments.Find(Id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.DepartmentDelete)]
        public IActionResult Delete(Department department)
        {

            _context.Departments.Remove(department);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
