
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MyFinalProject.Infrastructure.Data;
using MyFinalProject.Application.Abstractions.Services;
using MyFinalProject.Application.Security;
using MyFinalProject.Application.Dtos;


[Authorize]
public class DepartmentsController : Controller
{
    //private readonly IRepository<Department> _depRepository;
    private readonly ApplicationDbContext _context;
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(ApplicationDbContext context, IDepartmentService departmentService)
    {
        _context = context;
        _departmentService = departmentService;
        //_depRepository = depRepository;
        //_unitOfWork = unitOfWork;
    }

    // GET: DEPARTMENTS
    [Authorize(Policy =PermissionsNames.DepartmentView)]
    public async Task<IActionResult> Index()    
    {
        return View( _departmentService.GetAllDepartments());
    }

    // GET: DEPARTMENTS/Details/5
    [Authorize(Policy =PermissionsNames.DepartmentDetails)]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = _departmentService.GetDepartmentById(id.Value);
        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    // GET: DEPARTMENTS/Create
    [Authorize(Policy =PermissionsNames.DepartmentCreate)]
    public IActionResult Create()
    {
        return View();
    }

    // POST: DEPARTMENTS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = PermissionsNames.DepartmentCreate)]
    public async Task<IActionResult> Create([Bind("Id,Name")] DepartmentCreateDto department)
    {
        if (ModelState.IsValid)
        {
            //_unitOfWork.Departments.Add(department);
            //_unitOfWork.Save();
            _departmentService.CreateDepartment(department);
            _departmentService.SaveDepartments();
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }

    // GET: DEPARTMENTS/Edit/5
    [Authorize(Policy = PermissionsNames.DepartmentEdit)]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = _departmentService.GetDepartmentById(id.Value);
        if (department == null)
        {
            return NotFound();
        }
        return View(department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = PermissionsNames.DepartmentEdit)]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Employees")] DepartmentUpdateDto department)
    {
        if (id != department.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _departmentService.UpdateDepartment(department);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(department.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //_unitOfWork.Save();
            _departmentService.SaveDepartments();
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }

    // GET: DEPARTMENTS/Delete/5
    [Authorize(Policy = PermissionsNames.DepartmentDelete)]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department =  _departmentService.GetDepartmentById(id.Value);
        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    // POST: DEPARTMENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = PermissionsNames.DepartmentDelete)]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var department =  _departmentService.GetDepartmentById(id.Value);
        if (department != null)
        {
            _departmentService.DeleteDepartment(department.Id);
        }
        //_unitOfWork.Save();
        _departmentService.SaveDepartments();
        return RedirectToAction(nameof(Index));
    }

    private bool DepartmentExists(int? id)
    {
        return _context.Departments.Any(e => e.Id == id);
    }
}
