namespace OnlineShop.Domin.Entities.Categories
{
    public class Category : BaseEntity
    {
        //public long Id { get; set; }
        public string Title { get; set; }
        //public bool IsDeleted { get; set; }
        public virtual List<Product> Products{get; set;}
    }
}
