using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class AppUser:IdentityUser<int>
    {
        public string ad { get; set; }
        public string soyad { get; set; }

        public DateTime dogumTarihi { get; set; }

        public string cinsiyet { get; set; }

        public string telefonNumarasi { get; set; }

        public int ConfirmCodee { get; set; }
        public List<AppAntrenor> Antrenors { get; set; }

        public List<AppDanisan> Danisans { get; set; }



        // public String Imageurl { get; set; }


    }
}
