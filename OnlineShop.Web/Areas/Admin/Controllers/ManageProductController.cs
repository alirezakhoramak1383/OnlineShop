using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Products;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageProductController : Controller
    {
        private readonly IProductService _productService;
        public ManageProductController(IProductService productService)
        {
            _productService= productService;
        }
        public async Task<ActionResult<ProductServise>> Index()
        {
            var Product= await _productService.GetAllProductsAsync();
            return View("Index",Product);
        }
    }
}
