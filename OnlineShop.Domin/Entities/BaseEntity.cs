namespace OnlineShop.Domin.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
