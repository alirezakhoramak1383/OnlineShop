using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ManageCommentController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
