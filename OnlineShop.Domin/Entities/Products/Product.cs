using OnlineShop.Domin.Entities.Categories;

namespace OnlineShop.Domin.Entities.Products
{
    
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
