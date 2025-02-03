using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Web.Models
{
    public class UserLoginBindingModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Password { get; set; }
    }
}
