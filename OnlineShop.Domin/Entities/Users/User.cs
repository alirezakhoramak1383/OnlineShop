using OnlineShop.Domin.Entities.Products;

namespace OnlineShop.Domin.Entities.Users
{
    public class User
    {
        public long  Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Order { get; set; }
        public bool IsDeleted { get; set; }
        public string Password { get; set; }
        public IEnumerable<UserProduct> UserProducts { get; set; }
    }
}
