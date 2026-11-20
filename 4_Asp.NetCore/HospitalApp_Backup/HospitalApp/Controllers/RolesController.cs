using HospitalApp.Data;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Security;
using HospitalApp.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Controllers
{
    //[Authorize(Policy =PermissionsNames.RoleManagement)]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRoleService _roleService;

        public RolesController(ApplicationDbContext context, IRoleService roleService)
        {
            _context = context;
            _roleService = roleService;
        }


        [HttpGet]
        //[Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Index()
        {
            var roles = _roleService.GetAllRoles();
            return View(roles);
        }

        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Details(int Id)
        {
            var role = _roleService.GetRoleById(Id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpGet]
        //[Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Create(RoleCreateDto role)
        {
            if (ModelState.IsValid)
            {
                _roleService.CreateRole(role);
                _roleService.SaveRoles();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Update(int Id)
        {
            var role = _roleService.GetRoleById(Id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Update(RoleUpdateDto role)
        {
            if (ModelState.IsValid)
            {
                _roleService.UpdateRole(role);
                _roleService.SaveRoles();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Delete(int Id)
        {
            var role = _roleService.GetRoleById(Id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Delete(Role role)
        {

            _roleService.DeleteRole(role.Id);
            _roleService.SaveRoles();
            return RedirectToAction("Index");
        }

        [HttpGet]
        //[Authorize(Policy = PermissionsNames.RoleManagement)]
        public IActionResult AssignPermission(int Id)
        {
            var role = _roleService.GetRoleWithPermission(Id);
            if (role == null)
            {
                return NotFound();
            }

            var permissions = _roleService.GetAllPermissions();
            ViewBag.Allpermissions = permissions;

            ViewBag.RolePermission = role.Permissions.Select(p => p.Id).ToList();

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = PermissionsNames.RoleManagement)]
        public IActionResult AssignPermission(int Id, List<int> permissionIds)
        {
            _roleService.UpdateRoleWithPermissions(Id, permissionIds);

            return RedirectToAction("Index");
        }
    }
}
