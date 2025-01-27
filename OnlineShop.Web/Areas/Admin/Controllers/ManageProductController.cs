using Microsoft.AspNetCore.Mvc;
using OnlineShop.Model.ViewModel.Product;
using OnlineShop.Service.Products;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageProductController : Controller
    {
        private readonly IProductService _productService;
        public ManageProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ActionResult<ProductServise>> Index()
        {
            var Product = await _productService.GetAllProductsAsync();
            return View("Index", Product);
        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var Product = await _productService.GetProductByIdAsync(id.Value);
            return View(Product);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel model)
        {
            await _productService.UpdateProductAsync(model);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Create()
        {
            return View();
        }

    }
}
