using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfGenericDal<T> : GenericRepository<T> where T : class
    {
    }
}
