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
    public class DestinationManager : IGenericService<Destination>
    {
        IGenericDal<Destination> _destinationDal;

        public DestinationManager(IGenericDal<Destination> destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public List<Destination> TGetList()
        {
            return _destinationDal.GetList();
        }

        public void TAdd(Destination t)
        {
            _destinationDal.Insert(t);
        }

        public void TDelete(Destination t)
        {
            _destinationDal.Delete(t);
        }

        public Destination TGetById(int id)
        {
            return _destinationDal.GetByID(id);
        }

        public void TUpdate(Destination t)
        {
            _destinationDal.Update(t);
        }

        public List<Destination> TGetFilterById(int id, string str)
        {
            throw new NotImplementedException();
        }

        public List<Destination> TGetFilterWithIncludeById(int id, string str)
        {
            throw new NotImplementedException();
        }
    }
}
