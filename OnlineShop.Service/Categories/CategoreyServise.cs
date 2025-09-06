using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Domin.Entities.Categories;
using OnlineShop.Model.ViewModel.Category;

namespace OnlineShop.Service.Categories
{
    public interface ICategoryServise
    {
        Task<List<CategoryViewModel>> GetAllCategoriesAsync();
        Task<CategoryViewModel> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CategoryViewModel categoryViewModel);
        Task UpdateCategoryAsync(CategoryViewModel categoryViewModel);
        Task DeleteCategoryAsync(int id);
    }


    public class CategoreyServise : ICategoryServise
    {
        private readonly ShopContext _context;
        public CategoreyServise(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Where(x => x.IsDeleted == false)
                .Select(s => new CategoryViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                })
                .ToListAsync();
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories
                .Where(x => x.Id == id)
                .Select(s => new CategoryViewModel
                {
                    Id = s.Id,
                    Title = s.Title,

                }).FirstOrDefaultAsync();
        }

        public async Task CreateCategoryAsync(CategoryViewModel categoryViewModel)
        {
            var Category = new Category
            {
                Title = categoryViewModel.Title,
                IsDeleted = false
            };
            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(CategoryViewModel categoryViewModel)
        {
            var Category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == categoryViewModel.Id);
            if (Category != null && Category.IsDeleted == false)
            {
                Category.Title = categoryViewModel.Title;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category != null && category.IsDeleted == false)
            {
                category.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

    }
}
