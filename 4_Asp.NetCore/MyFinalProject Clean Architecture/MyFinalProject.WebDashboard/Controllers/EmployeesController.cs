using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFinalProject.Application.Abstractions.Services;
using MyFinalProject.Application.Dtos;
using MyFinalProject.Application.Security;
using MyFinalProject.Domain;
using MyFinalProject.Infrastructure.Data;


namespace MyFinalProject.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        // New code for Employees action methods ************** 

        // Inject the ApplicationDbContext into the controller

        //Dependency injection is used to provide the controller with an instance of the ApplicationDbContext,
        //which allows it to interact with the database.

        //private readonly IEmployeeRepository _empRepo;

        //private readonly IRepository<Employee> _empRepository;
        //private readonly IRepository<Department> _depRepository;
        private readonly ApplicationDbContext _context;
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeService _service;


        public EmployeesController(ApplicationDbContext context, IEmployeeService service)
            {
            _context = context;
            _service = service;
            }


            [HttpGet]
            public IActionResult GetAllEmployees()
            {
            List<EmployeeListDto> Employees = _context.Employees.Select(e => new EmployeeListDto
            {
                Name = e.Name,
                Salary = e.Salary,
                DepartmentName = e.Department != null ? e.Department.Name : null}).ToList();
            return Ok(Employees);
            }

            [HttpGet]
            [Authorize(Policy =PermissionsNames.EmployeeView)]
            public IActionResult Index()
            {

            var Employees = _service.GetAllEmployees();

            return View(Employees);
            }

            [HttpGet]
        [Authorize(Policy = PermissionsNames.EmployeeDetails)]
        public IActionResult Details(int Id)
            {
             var emp = _service.GetEmployeeById(Id);
             /*_context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == Id);*/

                if (emp == null)
                {
                    return NotFound();
                }
                return View(emp);
            }

            [HttpGet]
        [Authorize(Policy = PermissionsNames.EmployeeCreate)]
        public IActionResult Create()
            {
            LoadDepartments();
            return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
        [Authorize(Policy = PermissionsNames.EmployeeCreate)]
        public IActionResult Create(EmployeeCreateDto employee)
            {
                if (ModelState.IsValid)
                {
                //    _context.Employees.Add(employee);
                //_context.SaveChanges();
                _service.AddEmployees(employee);
                _service.SaveEmployee();
                    return RedirectToAction("Index");
                }
            LoadDepartments();
            return View(employee);

            }

            [HttpGet]
        [Authorize(Policy = PermissionsNames.EmployeeUpdate)]
        public IActionResult Update(int Id)
            {
            var emp = _service.GetEmployeeById(Id);
                if (emp == null)
                {
                    return NotFound();
                }
            LoadDepartments();
            return View(emp);
            }


        [HttpPost]
        [Authorize(Policy = PermissionsNames.EmployeeUpdate)]
        public IActionResult Update(EmployeeUpdateDto employee)
            {
                if (ModelState.IsValid)
                {
                //_context.Employees.Update(employee);
                //_context.SaveChangesAsync();
                _service.UpdateEmployees(employee);
                _service.SaveEmployee();
                    return RedirectToAction("Index");
                }
            LoadDepartments();
            return View(employee);
            }
        [HttpGet]
        [Authorize(Policy = PermissionsNames.EmployeeDelete)]
        public IActionResult Delete(int Id)
            {
            var emp = _service.GetEmployeeById(Id);
                if (emp == null)
                {
                    return NotFound();
                }
            LoadDepartments();
            return View(emp);
            }
            [HttpPost]
        [Authorize(Policy = PermissionsNames.EmployeeDelete)]
        public IActionResult Delete(Employee employee)
            {

            //_context.Employees.Remove(employee);
            //_context.SaveChanges();
            _service.DeleteEmployees(employee.Id);
            _service.SaveEmployee();
                return RedirectToAction("Index");


            }

        private void LoadDepartments()
        {
            IEnumerable<DepartmentDto> departments = _service.GetAllDepartment();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
        }

    }
}
