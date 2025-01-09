using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Domin.Entities.Categories;
using OnlineShop.Model.ViewModel.User;

namespace OnlineShop.Service.Categories
{
    public interface ICategoryServise
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(Category category);
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

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.categories.FindAsync(id);
        }

        public async Task CreateCategoryAsync(Category category)
        {
            _context.categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var Category = await _context.users.FindAsync(category.Id);
            if (category != null && Category.IsDeleted==false)
            {
                var UserViewModel = new EditViewModel
                {
                    Id = Category.Id,
                    FullName = Category.FullName,
                    Email = Category.Email,
                    Password = Category.Password
                };

            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.users.FindAsync(id);
            if (category != null && category.IsDeleted == false)
            {
                var DeleteUser = new EditViewModel
                {
                    IsDeleted = category.IsDeleted = true
                };

            }
            await _context.SaveChangesAsync();
        }
        
    }
}
