using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Domin.Entities.Categories;

namespace OnlineShop.Service.Categories
{
    public class CategoreyServise
    {
        private readonly ShopContext _shopContext;
        public CategoreyServise(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _shopContext.categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _shopContext.categories.FindAsync(id);
        }

        public async Task CreateCategoryAsync(Category category)
        {
            _shopContext.categories.Add(category);
            await _shopContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _shopContext.categories.Update(category);
            await _shopContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _shopContext.categories.FindAsync(id);
            if (category != null)
            {
                _shopContext.categories.Remove(category);
                await _shopContext.SaveChangesAsync();
            }
        }
        public interface ICategoryServise
        {
            Task<List<Category>> GetAllCategoriesAsync();
            Task<Category> GetCategoryByIdAsync(int id);
            Task CreateCategoryAsync(Category category);
            Task UpdateCategoryAsync(Category category);
            Task DeleteCategoryAsync(int id);
        }
    }
}
