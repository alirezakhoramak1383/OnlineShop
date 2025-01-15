using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domin.Entities.Products;
using OnlineShop.Domin.Entities.Users;
using OnlineShop.Model.ViewModel.Product;
using OnlineShop.Model.ViewModel.User;
using OnlineShop.Service.Users;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// .......
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        [Area("Admin")]
        public async Task<ActionResult<User>> Index()
        {
            var users = await _userService.GetUsersAsync();
            var result= users.Select(s => new EditViewModel
            {
                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email,
                Address = s.Address,
                Order = s.Order,
                IsDeleted = false,
                Password = s.Password
            }).ToList();
            return View("Index", result);
        }

    }
}
