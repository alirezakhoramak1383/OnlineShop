namespace OnlineShop.Model.ViewModel.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath{get; set;}
        public bool IsDeleted { get; set; }
      
    }
}
