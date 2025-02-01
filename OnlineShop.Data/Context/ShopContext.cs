using Microsoft.EntityFrameworkCore;
using OnlineShop.Domin.Entities.Categories;
using OnlineShop.Domin.Entities.Products;
using OnlineShop.Domin.Entities.Users;

namespace OnlineShop.Data.Context
{
    public class ShopContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options):base(options) 
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
