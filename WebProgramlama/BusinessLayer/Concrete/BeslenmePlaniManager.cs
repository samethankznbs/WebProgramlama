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
    public class BeslenmePlaniManager : IBeslenmePlaniService
    {
        IBeslenmePlaniDal _beslenmePlaniDal;

        public BeslenmePlaniManager(IBeslenmePlaniDal beslenmePlaniDal)
        {
            _beslenmePlaniDal = beslenmePlaniDal;
        }

        public void TAdd(BeslenmePlani entity)
        {
            _beslenmePlaniDal.Add(entity);
        }

        public void TDelete(BeslenmePlani entity)
        {
            _beslenmePlaniDal.Delete(entity);
        }

        public void TUpdate(BeslenmePlani entity)
        {
            _beslenmePlaniDal.Update(entity);
        }

        public List<BeslenmePlani> TGetAll()
        {
            return _beslenmePlaniDal.GetAll();
        }

        public BeslenmePlani TGetById(int id)
        {
            return _beslenmePlaniDal.GetById(id);
        }

        public List<BeslenmePlani> GetBeslenmeByAppDanisanId(int id)
        {
            return _beslenmePlaniDal.GetAll(x => x.AppDanisanId == id);
        }

      
    }
}
