using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Model.ViewModel.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }

        [Display(Name="نام محصول")]

        public string Name { get; set; }

        [Display(Name = "توضیحات")]

        public string Description { get; set; }

        [Display(Name = "مسیر تصویر")]

        public string ImagePath{get; set;}

        [Display(Name = "موجودی")]

        public int Existence { get; set; }

        [Display(Name = "دسته محصول")]

        public string categoryName { get; set; }

        public bool IsDeleted { get; set; }

       

    }
}
