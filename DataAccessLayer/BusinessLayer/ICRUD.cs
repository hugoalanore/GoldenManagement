using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    interface ICRUD  <T>
    {
        void Creat();

        Object GetByID();

        ICollection<T> GetAll();

        void Update(T obj);

        void Delete(T obj);
    }
}
