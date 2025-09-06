using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Model.ViewModel.Category
{
    public class CategoryViewModel
    {
        public long Id { get; set; }

        [Display(Name = "اسم دسته")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }
    }
}
