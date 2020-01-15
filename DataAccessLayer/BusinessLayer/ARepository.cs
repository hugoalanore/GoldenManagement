using DataAccessLayer.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    internal abstract class ARepository<T> : ICRUD<T>  where T : class
    {
        public void Create(T entity)
        {
            try
            {
                DBContext.Instance.Set<T>().Add(entity);
                Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error on Create", e);
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return DBContext.Instance.Set<T>().ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetAll", e);
            }
        }

        public T GetById(object id)
        {
            try
            {
                return DBContext.Instance.Set<T>().Find(id);
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetById", e);
            }
        }

        public void Update(T entity)
        {
            try
            {
                DBContext.Instance.Set<T>().Attach(entity);
                DBContext.Instance.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error on Update", e);
            }
        }

        public void Delete(object id)
        {
            try
            {
                T existing =  DBContext.Instance.Set<T>().Find(id);
                DBContext.Instance.Set<T>().Remove(existing);
                Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error on Delete", e);
            }
        }

        private void Save()
        {
            DBContext.Instance.SaveChanges();
        }
    }
}
