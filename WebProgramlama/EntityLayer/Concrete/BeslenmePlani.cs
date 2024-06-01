using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BeslenmePlani
    {
        [Key]
        public int Id { get; set; }
     
        public string hedef { get; set; }

        public string gunlukOgun { get; set; }
       
        public string kaloriHedef { get; set; }

        public DateTime beslenmePlanBaslangicTarihi { get; set; }

        public string planSuresi { get; set; }

        public int? AppDanisanId { get; set; }
        public AppDanisan AppDanisan { get; set; }

    }
}
