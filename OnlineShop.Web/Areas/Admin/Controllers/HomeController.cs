using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Context;
using OnlineShop.Domin.Entities.Users;
using OnlineShop.Model.ViewModel.User;
using OnlineShop.Service.Users;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopContext _context;
        private readonly IUserService _userService;
        public HomeController(ShopContext context,IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        [Area("Admin")]
        public async Task<ActionResult<User>> Index()
        {
            var users = await _userService.GetUsersAsync().Select(s => new EditViewModel
            {
                Id=s.Id,
                FullName=s.FullName,
                Email=s.Email,
                Address=s.Address,
                Order=s.order,
                IsDeleted=false,
                Password=s.Password

            });
            return View();
        }

    }
}
