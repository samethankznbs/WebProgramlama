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
    public class AntrenorManager : IAntrenorService
    {
        IAntrenorDal _antrenorDal;

        public AntrenorManager(IAntrenorDal antrenorDal)
        {
            _antrenorDal = antrenorDal;
        }

        public List<AppAntrenor> GetAntrenorById(int id)
        {
            return _antrenorDal.GetAll(x => x.AntrenorId == id);
        }
        public List<AppAntrenor> GetAntrenorByAppUserId(int id)
        {
            return _antrenorDal.GetAll(x => x.AppUserId == id);
        }

        public List<AppAntrenor> TGetAll()
        {
            return _antrenorDal.GetAll();
        }

        public AppAntrenor TGetById(int id)
        {
            return _antrenorDal.GetById(id);
        }
        public void TAdd(AppAntrenor entity)
        {
            _antrenorDal.Add(entity);
        }

        public void TDelete(AppAntrenor entity)
        {
            _antrenorDal.Delete(entity);
        }

        
        public void TUpdate(AppAntrenor entity)
        {
            _antrenorDal.Update(entity);

        }

        public List<AppAntrenor> GetAntrenorByUzmanlikALani(String deger)
        {
            return _antrenorDal.GetAll(x => x.UzmanlikAlani == deger);
        }

       
    }
}
