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
    public class MesajManager : IMesajService
    {
        IMesajDal _mesajDal;

        public MesajManager(IMesajDal mesajDal)
        {
            _mesajDal = mesajDal;
        }
        public void TAdd(mesaj entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(mesaj entity)
        {
            throw new NotImplementedException();
        }

        public List<mesaj> TGetAll()
        {
            throw new NotImplementedException();
        }

        public mesaj TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(mesaj entity)
        {
            throw new NotImplementedException();
        }
    }
}
