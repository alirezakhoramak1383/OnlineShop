using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Domin.Entities.Products;

namespace OnlineShop.Service.Products
{
    public class ProductServise : IProductService
    {
        private readonly ShopContext _context;

        public ProductServise(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.products.FindAsync(id);
        }

        public async Task CreateProductAsync(Product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product != null)
            {
                _context.products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
