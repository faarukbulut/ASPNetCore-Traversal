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
    public class ReservationManager : IGenericService<Reservation>
    {
        IGenericDal<Reservation> _reservationDal;

        public ReservationManager(IGenericDal<Reservation> reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            throw new NotImplementedException();
        }

        public Reservation TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> TGetFilterById(int id, string status)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> TGetFilterWithIncludeById(int id, string str)
        {
            return _reservationDal.GetListByFilterWithInclude(x => x.AppUserId == id && x.Status == str, x => x.Destination);
        }

        public List<Reservation> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Reservation t)
        {
            throw new NotImplementedException();
        }
    }
}
