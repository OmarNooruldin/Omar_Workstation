
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFinalProject.Models;
using MyFinalProject.Data;
using Microsoft.AspNetCore.Authorization;
using MyFinalProject.Security;
using MyFinalProject.Repositories.Base;
using MyFinalProject.Repositories.Roles;
using MyFinalProject.Services;
using MyFinalProject.Services.Base;
using MyFinalProject.Dtos;

[Authorize(Policy =PermissionsNames.RoleMangment)]
public class RolesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IRoleService _roleService;
    //private readonly IUnitOfWork _unitOfWork;
    //private readonly IRoleRepository _iRoleRepository;
    //private readonly IRepository<Role> _roleRepository;
    //private readonly IRepository<Permission> _perRepository;


    public RolesController(ApplicationDbContext context, IRoleService roleService)
    {
        _context = context;
        _roleService = roleService;
        //_roleRepository = roleRepository;
        //_iRoleRepository = iRoleRepository;
        //_perRepository = perRepository;
    }

    // GET: ROLES
    public async Task<IActionResult> Index()
    {
        return View( _roleService.GetAllRoles());
    }

    // GET: ROLES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var role = _roleService.GetRoleById(id.Value);
        if (role == null)
        {
            return NotFound();
        }

        return View(role);
    }

    // GET: ROLES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ROLES/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Permissions,Users")] RoleCreateDto role)
    {
        if (ModelState.IsValid)
        {
            _roleService.CreateRole(role);
            //await _context.SaveChangesAsync();
            _roleService.SaveRoles();
            return RedirectToAction(nameof(Index));
        }
        return View(role);
    }

    // GET: ROLES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var role = _roleService.GetRoleById(id.Value);
        if (role == null)
        {
            return NotFound();
        }
        return View(role);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Permissions,Users")] RoleUpdateDto role)
    {
        if (id != role.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _roleService.UpdateRole(role);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(role.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _roleService.SaveRoles();
            return RedirectToAction(nameof(Index));
        }
        return View(role);
    }

    // GET: ROLES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var role = _roleService.GetRoleById(id.Value);
        if (role == null)
        {
            return NotFound();
        }

        return View(role);
    }

    // POST: ROLES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var role = _roleService.GetRoleById(id.Value);
        if (role != null)
        {
            _roleService.DeleteRole(role.Id);
        }

        //await _context.SaveChangesAsync();
        _roleService.SaveRoles();
        return RedirectToAction(nameof(Index));
    }

    private bool RoleExists(int? id)
    {
        return _context.Roles.Any(e => e.Id == id);
    }

    [HttpGet]
    public IActionResult AssignPermission(int Id)
    {
        var role = _roleService.GetRoleWithPermission(Id);
        if(role == null)
        {
            return NotFound();
        }
        IEnumerable<PermissionDto> permissions = _roleService.GetAllPermissions();
        ViewBag.AllPermissions = permissions;

        ViewBag.RolePermission = role.Permissions.Select(p => p.Id).ToList();


        return View(role);
    }

    [HttpPost]
    public IActionResult AssignPermission(int Id, List<int>permissionIds)
    {
        _roleService.UpdateRoleWithPermissions(Id, permissionIds);

        return RedirectToAction("Index");
    }
}