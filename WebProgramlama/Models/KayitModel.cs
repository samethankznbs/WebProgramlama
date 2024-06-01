using System.ComponentModel.DataAnnotations;

namespace yazlabyeto.Models
{
	public class KayitModel
	{

       // public int Id { get; set; }
        [Required]
		public string ad { get; set; }

		[Required]
		
		public string soyad { get; set; }

		[Required]
	
		public DateTime dogumTarihi { get; set; }

		[Required]
		public string cinsiyet { get; set; }

		[Required]
		[Display(Name = "Telefon Numarası")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Geçersiz telefon numarası.")]
		public string telefonNumarasi { get; set; }


		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "kullaniciadi")]
        public string UserName { get; set; }

        [Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		
		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

	}
}
