using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Model.ViewModel.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }

        [Display(Name="نام محصول")]
        [Required(ErrorMessage ="{0} را وارد کنید")]

        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "مسیر تصویر")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string ImagePath{get; set;}

        [Display(Name = "موجودی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int Existence { get; set; }

        [Display(Name = "دسته محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public long CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool IsDeleted { get; set; }

       

    }
}
