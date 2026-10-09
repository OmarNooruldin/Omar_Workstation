using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Controllers
{
    [Authorize(Policy =PermissionsNames.PermissionManagement)]
    public class PermissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PermissionsController(ApplicationDbContext context) 
        { _context = context; }


        [HttpGet]
        [Authorize(Policy = PermissionsNames.PermissionManagement)]
        public IActionResult Index()
        {
            List<Permission> permissions = _context.Permissions.ToList();
            return View(permissions);
        }

        [Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Details(int Id)
        {
            Permission? permission = _context.Permissions.Find(Id);
            if (permission == null)
            {
                return NotFound();
            }
            return View(permission);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Create(Permission permission)
        {
            if (ModelState.IsValid)
            {
                _context.Permissions.Add(permission);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(permission);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Update(int Id)
        {
            Permission? permission = _context.Permissions.Find(Id);
            if (permission == null)
            {
                return NotFound();
            }
            return View(permission);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Update(Permission permission)
        {
            if (ModelState.IsValid)
            {
                _context.Permissions.Update(permission);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(permission);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Delete(int Id)
        {
            Permission? permission = _context.Permissions.Find(Id);
            if (permission == null)
            {
                return NotFound();
            }
            return View(permission);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Delete(Permission permission)
        {

            _context.Permissions.Remove(permission);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
