using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageCategoryController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
