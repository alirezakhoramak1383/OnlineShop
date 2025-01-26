using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    public class ManageCommentController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
