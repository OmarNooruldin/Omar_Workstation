using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Models.ViewModels;
using HospitalApplication.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HospitalApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        { _context = context; }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModels loginView, string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ReturnUrl = returnUrl;
                return View(loginView);
            }

            User? user = _context.Users.Include(u => u.Roles).
                         ThenInclude(r=>r.Permissions).FirstOrDefault(u=> u.Username == loginView.Username);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty,"Invalid UserName or Password");
                ViewBag.ReturnUrl = returnUrl;
                return View(loginView);
            }

            if (user.Password != loginView.Password)
            {
                ModelState.AddModelError(string.Empty, "Invalid UserName or Password");
                ViewBag.ReturnUrl = returnUrl;
                return View(loginView);
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name          , user.Name),
                new Claim(ClaimTypes.Email         , user.Email ?? string.Empty),
                new Claim("Username"               , user.Username)
            };

            foreach (var role in user?.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            List<string> permissions = user.Roles.SelectMany(r=>r.Permissions).Select(p=>p.Name).Distinct().ToList();

            foreach(string permission in permissions)
            {
                claims.Add(new Claim(PermissionsNames.ClaimType,permission));
            }

            ClaimsIdentity identity = new ClaimsIdentity(claims,
                                      CookieAuthenticationDefaults.AuthenticationScheme,
                                      ClaimTypes.Name,
                                      ClaimTypes.Role);

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            AuthenticationProperties properties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal, properties);
            if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
