using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public  class AppDanisan
    {
        [Key]
        public int DanisanId { get; set; }
        public string hedef { get; set; }
        public int kilo { get; set; }

        public int boy { get; set; }

        public int vucutYagOrani { get; set; }

        public int kasKutlesi { get; set; }

        public int vucutKitleİndex{ get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public int? AppAntrenorId { get; set; }
        public AppAntrenor AppAntrenor { get; set; }

        public List<EgzersizProgrami> EgzersizProgramis { get; set; }

        public List<BeslenmePlani> BeslenmePlanis{ get; set; }

       

      


    }
}
