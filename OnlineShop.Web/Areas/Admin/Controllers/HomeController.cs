using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domin.Entities.Users;
using OnlineShop.Model.ViewModel.User;
using OnlineShop.Service.Users;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<ActionResult<UserViewModel>> Index()
        {
            var users = await _userService.GetUsersAsync();
            return View("Index", users);
        }
        public  IActionResult LoadPartialView()
        {
            return PartialView("_PopupEdit"); 
        }


    }
}
