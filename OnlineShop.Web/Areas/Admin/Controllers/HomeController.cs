using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domin.Entities.Users;
using OnlineShop.Model.ViewModel.User;
using OnlineShop.Service.Users;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        [Area("Admin")]
        public async Task<ActionResult<UserViewModel>> Index()
        {
            var users = await _userService.GetUsersAsync();
            return View("Index", users);
        }
        [Area("admin")]
        public  IActionResult LoadPartialView()
        {
            return PartialView("_PopupEdit"); 
        }


    }
}
