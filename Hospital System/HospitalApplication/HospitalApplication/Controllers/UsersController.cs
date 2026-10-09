using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Controllers
{
    [Authorize(Policy =PermissionsNames.UserManagement)]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context) 
        {  _context = context; }


        [HttpGet]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Index()
        {
            List<User> users = _context.Users.ToList();
            return View(users);
        }

        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Details(int Id)
        {
            User? user = _context.Users.Find(Id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Update(int Id)
        {
            User? user = _context.Users.Find(Id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Delete(int Id)
        {
            User? user = _context.Users.Find(Id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Delete(User user)
        {

            _context.Users.Remove(user);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult AssignRole(int Id)
        {
            User? user = _context.Users.Include(e => e.Roles).FirstOrDefault(e => e.Id == Id);
            if (User == null)
            {
                return NotFound();
            }

            List<Role> roles = _context.Roles.ToList();
            ViewBag.AllRoles = roles;

            ViewBag.UserRole = user.Roles.Select(r => r.Id).ToList();

            return View(user);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult AssignRole(int id, List<int> roleIds)
        {
            User? user = _context.Users.Include(u => u.Roles).FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            user.Roles.Clear();
            List<Role> SelectRole = _context.Roles.Where(p => roleIds.Contains(p.Id)).ToList();

            foreach (Role role in SelectRole)
            {
                user.Roles.Add(role);
            }

            _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
