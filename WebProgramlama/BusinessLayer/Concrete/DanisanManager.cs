using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DanisanManager : IDanisanService
    {

        IDanisanDal _danisanDal;

        public DanisanManager(IDanisanDal danisanDal)
        {
            _danisanDal = danisanDal;
        }

        public void TAdd(AppDanisan entity)
        {
            _danisanDal.Add(entity);
        }
        public void TUpdate(AppDanisan entity)
        {
            _danisanDal.Update(entity);
        }

       

        public void TDelete(AppDanisan entity)
        {
            _danisanDal.Delete(entity);
        }

        public List<AppDanisan> TGetAll()
        {
            return _danisanDal.GetAll();
        }

        public AppDanisan TGetById(int id)
        {
            return _danisanDal.GetById(id);
        }

        public List<AppDanisan> GetDanisanById(int id)
        {
            return _danisanDal.GetAll(x => x.DanisanId == id);
        }

        //danisan panelinde tum danisanlar yerine sadece o danisanin bilgisini getirmek için kullandık
        public List<AppDanisan> GetDanisanByAppUserId(int id)
        {
            return _danisanDal.GetAll(x => x.AppUserId == id);
        }

        public List<AppDanisan> GetDanisanListWithAntrenor(int id)
        {
            return _danisanDal.GetListDanisanWithByAntrenor(id);
        }
    }
}
