using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDanisanService:IGenericService<AppDanisan>
    {
        List<AppDanisan> GetDanisanById(int id);
        List<AppDanisan> GetDanisanListWithAntrenor(int id);

      

    }
}
