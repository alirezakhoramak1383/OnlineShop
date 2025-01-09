using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Domin.Entities.Products;
using OnlineShop.Model.ViewModel.Product;
using OnlineShop.Model.ViewModel.User;

namespace OnlineShop.Service.Products
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }


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
            var Product = await _context.users.FindAsync(product.Id);
            if (Product != null && Product.IsDeleted==false)
            {
                var UserViewModel = new EditViewModel
                {
                    Id = Product.Id,
                    FullName = Product.FullName,
                    Email = Product.Email,
                    Password = Product.Password
                };

            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product != null && product.IsDeleted == false)
            {
                var Product = new ProductViewModel
                {
                    IsDeleted = product.IsDeleted = true

                };

            };

            await _context.SaveChangesAsync();
        }
    }
}


