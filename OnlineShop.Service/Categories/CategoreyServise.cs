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
        Task UpdateCategoryAsync(Category category);
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
            return await _context.categories.Where(x=>x.IsDeleted==false).Select(s=>new CategoryViewModel
            {
                Id = s.Id,
                Title = s.Title,
            })
                .ToListAsync();
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int id)
        {
            return await _context.categories.Where(x=>x.Id==id).Select(s=>new CategoryViewModel
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
            _context.categories.Add(Category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var Category = await _context.categories.FindAsync(category.Id);
            if (category != null && Category.IsDeleted==false)
            {
                var CategoryViewModel = new CategoryViewModel
                {
                    Id = Category.Id,
                    Title= category.Title,    
                };

            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.users.FindAsync(id);
            if (category != null && category.IsDeleted == false)
            {
                var DeleteUser = new CategoryViewModel
                {
                    IsDeleted = true
                };

            }
            await _context.SaveChangesAsync();
        }
        
    }
}
