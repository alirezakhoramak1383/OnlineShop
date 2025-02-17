using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Web.Models;
using System.Security.Claims;
using OnlineShop.Service.Users;
using OnlineShop.Model.ViewModel.User;
using OnlineShop.Domin.Entities.Users;

namespace OnlineShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShopContext _context;
        private readonly IUserService _userService;
        public AccountController(ShopContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // صفحه لاگین
        public IActionResult Login()
        {
            var isLogin = User.Identity.IsAuthenticated;

            if(isLogin)
                return Redirect("/Admin");

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
                ModelState.AddModelError("UserName", "نام کاربری اشتباه است");
                return View(model);
            }

            if (user.Password != model.Password)
            {
                ModelState.AddModelError("UserName", "کلمه عبور اشتباه است");
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

        public async Task<IActionResult> SignIn()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserViewModel userViewModel)
        {
            await _userService.CreateUserAsync(userViewModel);
            var user = User.Identity.IsAuthenticated;
            return Redirect("/Admin");
        }
    }
}
