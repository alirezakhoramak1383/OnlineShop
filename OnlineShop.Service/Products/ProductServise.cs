using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Domin.Entities.Products;
using OnlineShop.Model.ViewModel.Product;
using OnlineShop.Model.ViewModel.User;

namespace OnlineShop.Service.Products
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel> GetProductByIdAsync(int id);
        Task CreateProductAsync(ProductViewModel productViewModel);
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

        public async Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            return await _context.products.Where(x=>x.IsDeleted==false).Select(s=> new ProductViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ImagePath = s.ImagePath,
                Existence = s.Existence,
              
            })
              .ToListAsync();
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            return await _context.products.Where(x=>x.Id==id && x.IsDeleted==false).Select(s=>new ProductViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ImagePath = s.ImagePath,
                Existence = s.Existence,

            })
                .FirstOrDefaultAsync();
        }

        public async Task CreateProductAsync(ProductViewModel productViewModel)
        {
            var product = new Product
            {
                Name = productViewModel.Name,
                Description = productViewModel.Description,
                ImagePath = productViewModel.ImagePath,
                Existence= productViewModel.Existence,
                IsDeleted = false
            };
             _context.products.Add(product);
            await _context.SaveChangesAsync();
      
        }

        public async Task UpdateProductAsync(Product product)
        {
            var Product = await _context.products.FindAsync(product.Id);
            if (Product != null && Product.IsDeleted==false)
            {
                var ProductViewModel = new ProductViewModel
                {
                   Name= product.Name,
                   Description= product.Description,
                   ImagePath = product.ImagePath,
                   Existence= product.Existence,  
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
                    IsDeleted = true
                };
            };
            await _context.SaveChangesAsync();
        }
    }
}


