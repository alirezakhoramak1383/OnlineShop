using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    public class ManageCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
