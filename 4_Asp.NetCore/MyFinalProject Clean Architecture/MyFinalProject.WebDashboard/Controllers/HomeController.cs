using Microsoft.AspNetCore.Mvc;
using MyFinalProject.Models;
using System.Diagnostics;
using System.Net;

namespace MyFinalProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {


            Employee emp = new Employee();
            Employee emp1 = new Employee();
            Employee emp2 = new Employee();
            Employee emp3 = new Employee();

            emp.Id = 1;
            emp.Name = "Omar";
            emp.Email = "om@gamil.com";
            emp.Address = "KSA";
            emp.City = "DMM";
            emp.Phone = "1234567890";

            emp1.Id = 2;
            emp1.Name = "Ahmed";
            emp1.Email = "oah@gamil.com";
            emp.Address = "KSA";
            emp1.City = "Cairo";
            emp1.Phone = "1234512345";

            emp2.Id = 3;
            emp2.Name = "Fatimah";
            emp2.Email = "ft@gamil.com";
            emp.Address = "KSA";
            emp2.City = "JED";
            emp2.Phone = "1234123400";

            emp3.Id = 4;
            emp3.Name = "Mohammed";
            emp3.Email = "moe@gamil.com";
            emp.Address = "KSA";
            emp3.City = "RIYADH";
            emp3.Phone = "1231231230" ;

            return View(emp);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
