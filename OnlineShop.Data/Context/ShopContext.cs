using Microsoft.EntityFrameworkCore;
using OnlineShop.Domin.Entities.Categories;
using OnlineShop.Domin.Entities.Products;
using OnlineShop.Domin.Entities.Users;

namespace OnlineShop.Data.Context
{
    public class ShopContext:DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserInRole> UserinRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options):base(options) 
        {


        }
        
            
        
    }
}
