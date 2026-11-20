using HospitalApplication.Data;
using HospitalApplication.Dtos;
using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;
using HospitalApplication.Security;
using HospitalApplication.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Controllers
{
    [Authorize(Policy =PermissionsNames.PermissionManagement)]
    public class PermissionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPermissionService _permissionService;

        public PermissionsController(ApplicationDbContext context, IPermissionService permissionService) 
        {
            _context = context;
            _permissionService = permissionService;
        }


        [HttpGet]
        [Authorize(Policy = PermissionsNames.PermissionManagement)]
        public IActionResult Index()
        {
            var permissions = _permissionService.GetAllPermissions();
            return View(permissions);
        }

        [Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Details(int Id)
        {
            var permission = _permissionService.GetPermissionById(Id);
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
        public IActionResult Create(PermissionCreateDto permission)
        {
            if (ModelState.IsValid)
            {
                _permissionService.CreatePermission(permission);
                _permissionService.SavePermission();
                return RedirectToAction("Index");
            }
            return View(permission);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Update(int Id)
        {
            var permission = _permissionService.GetPermissionById(Id);
            if (permission == null)
            {
                return NotFound();
            }
            return View(permission);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Update(PermissionUpdateDto permission)
        {
            if (ModelState.IsValid)
            {
                _permissionService.UpdatePermission(permission);
                _permissionService.SavePermission();
                return RedirectToAction("Index");
            }
            return View(permission);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Delete(int Id)
        {
            var permission = _permissionService.GetPermissionById(Id);
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

            _permissionService.DeletePermission(permission.Id);
            _permissionService.SavePermission();
            return RedirectToAction("Index");
        }
    }
}
