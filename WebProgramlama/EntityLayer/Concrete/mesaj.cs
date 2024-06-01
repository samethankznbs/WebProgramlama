
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class mesaj
    {
        [Key]
        public int user_password { get; set; }
        public int gonderen_id { get; set; }

        public int alici_id { get; set; }

        public string text { get; set; }

        public bool durum_kontrol { get; set; }
    }
}
