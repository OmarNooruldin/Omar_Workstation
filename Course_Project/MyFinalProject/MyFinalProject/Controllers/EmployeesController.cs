using Microsoft.AspNetCore.Mvc;
using MyFinalProject.Data;
using MyFinalProject.Models;

namespace MyFinalProject.Controllers
{
    public class EmployeeController : Controller
    {
        //public IActionResult Index()
        //{
        //    List<Employee> emps = new List<Employee>();

        //    Employee emp = new Employee()
        //    {
        //        Id = 1,
        //        Name = "Omar",
        //        Email = "om@gamil.com",
        //        Address = "KSA",
        //        City = "DMM",
        //        Phone = "1234567890",
        //        Salary = 15000
        //    };

        //    Employee emp1 = new Employee()
        //    {
        //        Id = 2,
        //        Name = "Ahmed",
        //        Email = "oah@gamil.com",
        //        Address = "KSA",
        //        City = "Cairo",
        //        Phone = "1234512345",
        //        Salary = 25000
        //    };

        //    Employee emp2 = new Employee()
        //    {
        //        Id = 3,
        //        Name = "Fatimah",
        //        Email = "ft@gamil.com",
        //        Address = "KSA",
        //        City = "JED",
        //        Phone = "1234123400",
        //        Salary = 20000
        //    };

        //    Employee emp3 = new Employee()
        //    {
        //        Id = 4,
        //        Name = "Mohammed",
        //        Email = "moe@gamil.com",
        //        Address = "KSA",
        //        City = "RIYADH",
        //        Phone = "123123123",
        //        Salary = 10000
        //    };
        //    emps.Add(emp);
        //    emps.Add(emp1);
        //    emps.Add(emp2);
        //    emps.Add(emp3);

        //    return View(emps);
        //}


        // Dependency injection 
        // Inject the ApplicationDbContext 

        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // New Code for Employees action methods

        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> Employees = _context.Employee.ToList();
            return View(Employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emps)
        {
            if (ModelState.IsValid)
            {
                _context.Employee.Add(emps);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();

    }
}
}
