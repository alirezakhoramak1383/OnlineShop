namespace OnlineShop.Model.ViewModel.Product
{
    public class ProductViewModelGET
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Existence { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
