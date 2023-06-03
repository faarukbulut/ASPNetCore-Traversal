using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IGenericService<About>
    {
        IGenericDal<About> _aboutDal;

        public AboutManager(IGenericDal<About> aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public List<About> TGetList()
        {
            return _aboutDal.GetList();
        }

        public void TAdd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }

        public List<About> TGetFilterById(int id, string str)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetFilterWithIncludeById(int id, string str)
        {
            throw new NotImplementedException();
        }
    }
}
