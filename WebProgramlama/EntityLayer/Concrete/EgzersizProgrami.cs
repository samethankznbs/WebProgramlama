using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class EgzersizProgrami
    {
        [Key]
       public int Id { get; set; }
       public string egzersizAdi { get; set; }

       public string hedef { get; set; }

       public int setSayisi { get; set; }

       public int tekrarSayisi { get; set; }

       public DateTime programBaslangicTarihi { get; set; }

       public string programSuresi { get; set; }

        public int AppDanisanId { get; set; }
        public AppDanisan AppDanisan { get; set; }

    }
}
