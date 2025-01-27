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
        Task CreateProductAsync(ProductViewModel ProductViewModel);
        Task UpdateProductAsync(ProductViewModel ProductViewModel);
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
            return await _context.products.Where(x=>x.IsDeleted==false).Include(x => x.Category).Select(s=> new ProductViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ImagePath = s.ImagePath,
                Existence = s.Existence,
                categoryName=s.Category.Title
              
            })
              .ToListAsync();
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            return await _context.products.Where(x=>x.Id==id && x.IsDeleted==false).Include(x=>x.Category).Select(s=>new ProductViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ImagePath = s.ImagePath,
                Existence = s.Existence,  
                categoryName=s.Category.Title
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

        public async Task UpdateProductAsync(ProductViewModel productViewModel)
        {
            var Product = await _context.products.Include(x=>x.Category).FirstOrDefaultAsync(x=>x.Id== productViewModel.Id);
            if (Product != null && Product.IsDeleted==false)
            {
                Product.Name = productViewModel.Name;
                Product.Description = productViewModel.Description;
                Product.ImagePath = productViewModel.ImagePath;
                Product.Existence = productViewModel.Existence;
                Product.Category.Title = productViewModel.categoryName;
                
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


