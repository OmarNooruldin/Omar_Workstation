
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFinalProject.Data;
using MyFinalProject.Dtos;
using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;
using MyFinalProject.Repositories.Users;
using MyFinalProject.Security;
using MyFinalProject.Services.Base;

[Authorize(Policy =PermissionsNames.UserMangment)]
public class UsersController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IUserService _userService;
    //private readonly IUnitOfWork _unitOfWork;
    //private readonly IUserRepository _iUsersRepository;
    //private readonly IRepository<User> _userRepository;
    //private readonly IRepository<Role> _roleRepository;

    public UsersController(ApplicationDbContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
        //_unitOfWork = unitOfWork;
        //_iUsersRepository = iUsersRepository;
        //_userRepository = userRepository;
        //_roleRepository = roleRepository;
        
    }

    // GET: USERS
    public async Task<IActionResult> Index()    
    {
        return View( _userService.GetAllUsers());
    }

    // GET: USERS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = _userService.GetUserById(id.Value);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // GET: USERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: USERS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone,Username,Password,Roles")] UserCreateDto user)
    {
        if (ModelState.IsValid)
        {
            _userService.CreateUser(user);
            //await _context.SaveChangesAsync();
            _userService.SaveUsers();
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    // GET: USERS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = _userService.GetUserById(id.Value);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // POST: USERS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Email,Phone,Username,Password,Roles")] UserUpdateDto user)
    {
        if (id != user.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _userService.UpdateUser(user);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _userService.SaveUsers();
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    // GET: USERS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = _userService.GetUserById(id.Value);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // POST: USERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var user = _userService.GetUserById(id.Value);
        if (user != null)
        {
            _userService.DeleteUser(user.Id);
        }

        //await _context.SaveChangesAsync();
        //_unitOfWork.Save();
        _userService.SaveUsers();
        return RedirectToAction(nameof(Index));
    }

    private bool UserExists(int? id)
    {
        return _context.Users.Any(e => e.Id == id);
    }

    [HttpGet]
    public IActionResult AssignRole(int Id)
    {
        var user = _userService.GetUserWithRoles(Id);
        if (user == null)
        {
            return NotFound();
        }

        var roles = _userService.GetAllRoles();
        ViewBag.AllRoles = roles;

        ViewBag.UserRoles = user.Roles.Select(r => r.Id).ToList();

        return View(user);
    }


    [HttpPost]
    public IActionResult AssignRole(int Id, List<int> rolesIds)
    {   
        _userService.UpdateUserWithRole(Id, rolesIds);
        
        return RedirectToAction("Index");
    }
}
