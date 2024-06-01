using System.ComponentModel.DataAnnotations;

namespace yazlabyeto.Models
{
    public class RolModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen rol adı giriniz:")]
        public string name { get; set; }
    }
}
