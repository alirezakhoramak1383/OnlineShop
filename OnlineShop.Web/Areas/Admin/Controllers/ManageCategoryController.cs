using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Model.ViewModel.Category;
using OnlineShop.Service.Categories;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ManageCategoryController : Controller
    {
        private readonly ICategoryServise _categoryServise;
        public ManageCategoryController(ICategoryServise categoryServise)
        {
            _categoryServise = categoryServise;
        }
        public async Task<ActionResult> Index()
        {
            var Category = await _categoryServise.GetAllCategoriesAsync();
            return View(Category);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id==null)
                return NotFound();
            
            var categories = await _categoryServise.GetCategoryByIdAsync(id.Value);
            return View(categories);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryViewModel);
            }
            await _categoryServise.UpdateCategoryAsync(categoryViewModel);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CategoryViewModel categoryViewModel)
        {
            await _categoryServise.CreateCategoryAsync(categoryViewModel);
            return RedirectToAction("Index");
        }
    }
}
