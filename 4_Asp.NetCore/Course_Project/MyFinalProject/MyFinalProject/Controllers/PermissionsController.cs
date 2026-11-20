
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFinalProject.Models;
using MyFinalProject.Data;
using Microsoft.AspNetCore.Authorization;
using MyFinalProject.Security;
using MyFinalProject.Repositories.Base;
using MyFinalProject.Services.Base;
using MyFinalProject.Dtos;

[Authorize(Policy = PermissionsNames.PermissionMangment)]
public class PermissionsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IPermissionService _permissionService;
    //private readonly IUnitOfWork _unitOfWork;
    //private readonly IRepository<Permission> _perReository;

    public PermissionsController(ApplicationDbContext context, IPermissionService permissionService)
    {
        _context = context;
        _permissionService = permissionService;
        //_unitOfWork = unitOfWork;
        //_perReository = perReository;
    }

    // GET: PERMISSIONS
    public async Task<IActionResult> Index()    
    {
        return View( _permissionService.GetAllPermissions());
    }

    // GET: PERMISSIONS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var permission = _permissionService.GetPermissionById(id.Value);
        if (permission == null)
        {
            return NotFound();
        }

        return View(permission);
    }

    // GET: PERMISSIONS/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Roles")] PermissionCreateDto permission)
    {
        if (ModelState.IsValid)
        {
            _permissionService.CreatePermission(permission);
            _permissionService.SavePermission();
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(permission);
    }

    // GET: PERMISSIONS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var permission = _permissionService.GetPermissionById(id.Value);
        if (permission == null)
        {
            return NotFound();
        }
        return View(permission);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Roles")] PermissionUpdateDto permission)
    {
        if (id != permission.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
               //_unitOfWork.Permissions.Update(permission);
                //await _context.SaveChangesAsync();
                _permissionService.UpdatePermission(permission);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionExists(permission.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //_unitOfWork.Save();
            _permissionService.SavePermission();
            return RedirectToAction(nameof(Index));
        }
        return View(permission);
    }

    // GET: PERMISSIONS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var permission = _permissionService.GetPermissionById(id.Value);
        if (permission == null)
        {
            return NotFound();
        }

        return View(permission);
    }

    // POST: PERMISSIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var permission = _permissionService.GetPermissionById(id.Value);
        if (permission != null)
        {
            _permissionService.DeletePermission(permission.Id);
        }
        _permissionService.SavePermission();
        //await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PermissionExists(int? id)
    {
        return _context.Permissions.Any(e => e.Id == id);
    }
}
