using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDanisanRepository : GenericRepository<AppDanisan>, IDanisanDal
    {
        public List<AppDanisan> GetListDanisanWithByAntrenor(int id)
        {
            using (var c = new Context())
            {
                return c.Danisans.Where(x => x.AppAntrenorId == id).ToList();
            }
        }
    }
}
