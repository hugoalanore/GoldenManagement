using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    internal interface ICRUD<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T Create(T entity);
        T Update(T entity);
        void Delete(object id);
    }
}
