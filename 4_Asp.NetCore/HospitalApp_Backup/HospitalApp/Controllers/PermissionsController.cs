using HospitalApp.Data;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Security;
using HospitalApp.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Controllers
{
    //[Authorize(Policy =PermissionsNames.PermissionManagement)]
    public class PermissionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionService _permissionService;

        public PermissionsController(ApplicationDbContext context, IPermissionService permissionService, IUnitOfWork unitOfWork) 
        {
            _context = context;
            _permissionService = permissionService;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        //[Authorize(Policy = PermissionsNames.PermissionManagement)]
        public IActionResult Index()
        {
            var permissions = _permissionService.GetAllPermissions();
            return View(permissions);
        }

        //[Authorize(Policy =PermissionsNames.PermissionManagement)]
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
        //[Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Create(Permission permission)
        {
            if (ModelState.IsValid)
            {
                //_permissionService.CreatePermission(permission);
                //_permissionService.SavePermission();
                _unitOfWork.Permissions.Add(permission);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(permission);
        }

        [HttpGet]
        //[Authorize(Policy =PermissionsNames.PermissionManagement)]
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
        //[Authorize(Policy =PermissionsNames.PermissionManagement)]
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
        //[Authorize(Policy =PermissionsNames.PermissionManagement)]
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
        //[Authorize(Policy =PermissionsNames.PermissionManagement)]
        public IActionResult Delete(Permission permission)
        {

            _permissionService.DeletePermission(permission.Id);
            _permissionService.SavePermission();
            return RedirectToAction("Index");
        }
    }
}
