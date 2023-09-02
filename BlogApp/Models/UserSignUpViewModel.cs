using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen ad soyad giriniz")]
        public string NameSurename { get; set; }
        
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string Password { get; set; }
        
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifre uyuşmuyor")]
        public string ConfirmPassword { get; set; }
        
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lütfen mail giriniz")]
        public string Mail { get; set; }
        
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string UserName { get; set; }
        
    }
}

