using HospitalApplication.Data;
using HospitalApplication.Dtos;
using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;
using HospitalApplication.Repositories.Users;
using HospitalApplication.Security;
using HospitalApplication.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Controllers
{
    [Authorize(Policy =PermissionsNames.UserManagement)]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public UsersController(ApplicationDbContext context, IUserService userService) 
        { 
            _context = context;
            _userService = userService;
        }


        [HttpGet]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Details(int Id)
        {
            var user = _userService.GetUserById(Id);
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
        public IActionResult Create(UserCreateDto user)
        {
            if (ModelState.IsValid)
            {
                _userService.CreateUser(user);
                _userService.SaveUsers();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Update(int Id)
        {
            var user = _userService.GetUserById(Id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Update(UserDto user)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
                _userService.SaveUsers();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Delete(int Id)
        {
            var user = _userService.GetUserById(Id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult Delete(UserDto user)
        {

            _userService.DeleteUser(user.Id);
            _userService.SaveUsers();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult AssignRole(int Id)
        {
            var user = _userService.GetUserWithRoles(Id);
            if (User == null)
            {
                return NotFound();
            }

            var roles = _userService.GetAllRoles();
            ViewBag.AllRoles = roles;

            ViewBag.UserRole = user?.Roles?.Select(r => r.Id).ToList();

            return View(user);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.UserManagement)]
        public IActionResult AssignRole(int Id, List<int> roleIds)
        {
            _userService.UpdateUserWithRole(Id, roleIds);

            return RedirectToAction("Index");
        }
    }
}
