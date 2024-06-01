using System.ComponentModel.DataAnnotations;

namespace yazlabyeto.Areas.Admin.Models
{
    public class KullaniciGuncelleModel
    {

        public int Id { get; set; }
        public string ad { get; set; }

     
        public string soyad { get; set; }

       

        public DateTime dogumTarihi { get; set; }

   
        public string cinsiyet { get; set; }

  
        public string telefonNumarasi { get; set; }


       
        public string Email { get; set; }

        public string UserName { get; set; }

     
      
        public string Password { get; set; }

        public int ConfirmCodee { get; set; }


    }
}
