using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDanisanDal:IGenericDal<AppDanisan>
    {

        List<AppDanisan> GetListDanisanWithByAntrenor(int id);
    }
}
