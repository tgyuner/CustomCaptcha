using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CaptchaModel
    {
        [Display(Name = "Doğrulama Kodu")]
        [Required(ErrorMessage = "Lütfen doğrulama kodunu boş bırakmayınız.")]
        public string Captcha { get; set; }
    }
}