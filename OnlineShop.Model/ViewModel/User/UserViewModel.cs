using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Model.ViewModel.User
{
    public class UserViewModel
    {
        public long Id { get; set; }

        [Display(Name ="نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "سفارش")]
        public string Order { get; set; }
    }
}
