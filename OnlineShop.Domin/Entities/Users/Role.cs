namespace OnlineShop.Domin.Entities.Users
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserInRole> UserInRoles { get; set; }
    }
}
