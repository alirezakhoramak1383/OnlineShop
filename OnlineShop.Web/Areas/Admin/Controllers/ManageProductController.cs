using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Model.ViewModel.Product;
using OnlineShop.Service.Categories;
using OnlineShop.Service.Products;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ManageProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryServise _categoryServise;
        private readonly ShopContext _context;


        public ManageProductController(IProductService productService, ShopContext context)
        {
            _productService = productService;
            _context = context;
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

            ViewBag.Categories = await _context.Categories.Select(s => new
            {
                s.Id,
                s.Title
            }).ToListAsync();
            var Product = await _productService.GetProductByIdAsync(id.Value);
            return View(Product);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _productService.UpdateProductAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.Select(s => new
            {
                s.Id,
                s.Title
            }).ToListAsync();

            return View();

        }
        [HttpPost]
        public async Task<ActionResult> Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _context.Categories.Select(s => new
                {
                    s.Id,
                    s.Title
                }).ToListAsync();
                return View(productViewModel);
            }

            await _productService.CreateProductAsync(productViewModel);
            return RedirectToAction("Index");
        }
    }

}

