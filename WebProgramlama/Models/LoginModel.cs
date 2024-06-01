using System.ComponentModel.DataAnnotations;

namespace yazlabyeto.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="e postayı giriniz:")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "sifreyi giriniz:")]
        public string Password { get; set; }
    }
}
