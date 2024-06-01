using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class AppAntrenor
    {
        [Key]
        public int AntrenorId { get; set; }
        public string UzmanlikAlani { get; set; }
        public string Deneyim { get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public List<AppDanisan> Danisans { get; set; }
      
     
    }
}
