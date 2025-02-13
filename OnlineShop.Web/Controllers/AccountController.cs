using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Web.Models;
using System.Security.Claims;

namespace OnlineShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShopContext _context;

        public AccountController(ShopContext context)
        {
            _context = context;
        }

        // صفحه لاگین
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginBindingModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _context.Users.Where(u => u.Email == model.UserName).FirstOrDefaultAsync();

            if (user == null)
            {
                ModelState.AddModelError("UserName", "نام کاربری یا کلمه عبور اشتباه است");
                return View(model);
            }

            if (user.Password != model.Password)
            {
                ModelState.AddModelError("UserName", "نام کاربری یا کلمه عبور اشتباه است");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("FullName", user.FullName),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return Redirect("/Admin");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Account/Login");
        }
    }
}
