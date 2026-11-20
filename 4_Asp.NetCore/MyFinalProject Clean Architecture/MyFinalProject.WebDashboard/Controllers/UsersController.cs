using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFinalProject.Application.Abstractions.Repositories.Base;
using MyFinalProject.Application.Security;
using MyFinalProject.Domain;
using MyFinalProject.Infrastructure.Data;


[Authorize(Policy =PermissionsNames.UserMangment)]
public class UsersController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;
    //private readonly IUserRepository _iUsersRepository;
    //private readonly IRepository<User> _userRepository;
    //private readonly IRepository<Role> _roleRepository;

    public UsersController(ApplicationDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
        //_iUsersRepository = iUsersRepository;
        //_userRepository = userRepository;
        //_roleRepository = roleRepository;
        
    }

    // GET: USERS
    public async Task<IActionResult> Index()    
    {
        return View( _unitOfWork.Users.GetAll());
    }

    // GET: USERS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = _unitOfWork.Users.GetById(id.Value);
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
    public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone,Username,Password,Roles")] User user)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Users.Add(user);
            //await _context.SaveChangesAsync();
            _unitOfWork.Save();
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

        var user = _unitOfWork.Users.GetById(id.Value);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // POST: USERS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Email,Phone,Username,Password,Roles")] User user)
    {
        if (id != user.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _unitOfWork.Users.Update(user);
                _unitOfWork.Save();
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

        var user = _unitOfWork.Users.GetById(id.Value);
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
        var user = _unitOfWork.Users.GetById(id.Value);
        if (user != null)
        {
           _unitOfWork.Users.Delete(user);
        }

        //await _context.SaveChangesAsync();
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }

    private bool UserExists(int? id)
    {
        return _context.Users.Any(e => e.Id == id);
    }

    [HttpGet]
    public IActionResult AssignRole(int Id)
    {
        User? user = _unitOfWork.Users.GetUserWithRoles(Id);
        if (user == null)
        {
            return NotFound();
        }

        IEnumerable<Role> roles = _unitOfWork.Roles.GetAll();
        ViewBag.AllRoles = roles;

        ViewBag.UserRoles = user.Roles.Select(r => r.Id).ToList();

        return View(user);
    }
    [HttpPost]
    public IActionResult AssignRole(int Id, List<int> rolesIds)
    {
        User? user = _unitOfWork.Users.GetUserWithRoles(Id);
        if (user == null)
        {
            return NotFound();
        }
        user.Roles.Clear();

        List<Role> SelectRole = _context.Roles.Where(r => rolesIds.Contains(r.Id)).ToList();

        foreach (Role role in SelectRole)
        {
            user.Roles.Add(role);
            _unitOfWork.Users.Update(user);
        }
        //_context.SaveChanges();
        _unitOfWork.Save();
        return RedirectToAction("Index");
    }
}
