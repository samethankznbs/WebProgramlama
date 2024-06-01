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
    public class EgzersizProgramiManager : IEgzersizProgramiService
    {
        IEgzersizProgramiDal _egzersizProgramiDal;

        public EgzersizProgramiManager(IEgzersizProgramiDal egzersizProgramiDal)
        {
            _egzersizProgramiDal = egzersizProgramiDal;
        }

        public void TAdd(EgzersizProgrami entity)
        {
            _egzersizProgramiDal.Add(entity);
            
        }

        public void TDelete(EgzersizProgrami entity)
        {
            _egzersizProgramiDal.Delete(entity);
        }

      
        public void TUpdate(EgzersizProgrami entity)
        {
            _egzersizProgramiDal.Update(entity);
        }

        public List<EgzersizProgrami> TGetAll()
        {
           return _egzersizProgramiDal.GetAll();
        }

        public EgzersizProgrami TGetById(int id)
        {
            return _egzersizProgramiDal.GetById(id);
        }


        public List<EgzersizProgrami> GetEgzersizByAppDanisanId(int id)
        {
            return _egzersizProgramiDal.GetAll(x => x.AppDanisanId == id);
        }
    }
}
