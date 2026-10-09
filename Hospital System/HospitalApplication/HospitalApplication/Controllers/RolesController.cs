using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Controllers
{
    [Authorize(Policy =PermissionsNames.RoleManagement)]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        { _context = context; }


        [HttpGet]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Index()
        {
            List<Role> roles = _context.Roles.ToList();
            return View(roles);
        }

        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Details(int Id)
        {
            Role? role = _context.Roles.Find(Id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                _context.Roles.AddAsync(role);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Update(int Id)
        {
            Role? role = _context.Roles.Find(Id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Update(Role role)
        {
            if (ModelState.IsValid)
            {
                _context.Roles.Update(role);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult Delete(int Id)
        {
            Role? role = _context.Roles.Find(Id);
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

            _context.Roles.Remove(role);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult AssignPermission(int Id)
        {
            Role? role = _context.Roles.Include(r=>r.Permissions).FirstOrDefault(r=>r.Id == Id);
            if (role == null)
            {
                return NotFound();
            }

            List<Permission> permissions = _context.Permissions.ToList();
            ViewBag.AllPermissions = permissions;

            ViewBag.RolePermission = role.Permissions.Select(p=>p.Id).ToList();

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.RoleManagement)]
        public IActionResult AssignPermission(int Id,List<int> permissionIds)
        {
            Role? role = _context.Roles.Include(r => r.Permissions).FirstOrDefault(r => r.Id == Id);
            if (role == null)
            {
                return NotFound();
            }

            role.Permissions.Clear();

            List<Permission> SelectPermission = _context.Permissions.Where(p=> permissionIds.Contains(p.Id)).ToList();

            foreach (Permission permission in SelectPermission)
            {
                role.Permissions.Add(permission);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
