using OnlineShop.Domin.Entities.Categories;
using OnlineShop.Domin.Entities.Users;

namespace OnlineShop.Domin.Entities.Products
{
    
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Existence { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public IEnumerable<UserProduct> UserProducts { get; set; }
    }

    public class UserProduct
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
