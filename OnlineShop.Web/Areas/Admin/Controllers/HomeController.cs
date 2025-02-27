﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Users;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public  IActionResult Index()
        {

            int x = 10;

            int y = UserExtension.PlusOne(x);
            int z = x.PlusOne();

            var userId = User.GetUserId();
            var fullName = User.GetFullName();

            var isLogin = User.Identity.IsAuthenticated;

            //// دریافت شناسه کاربر از Claims
            //var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");

            //if (userIdClaim != null)
            //{
            //    // تبدیل شناسه کاربر به int
            //    var userId = Convert.ToInt32(userIdClaim.Value);

            //    // دریافت اطلاعات کاربر از سرویس
            //    var user = await _userService.GetUserByIdAsync(userId);

            //    // ارسال پیام خوش‌آمدگویی به ویو
            //    ViewBag.greetingMessage = $"سلام {user.FullName}! خوش آمدید.";

            //    return View(user);
            //}
            //else
            //{
            //    // اگر شناسه کاربر موجود نباشد، هدایت به صفحه لاگین
            //    return RedirectToAction("Login", "Account");
            //}

            return View();
        }
    }
}
