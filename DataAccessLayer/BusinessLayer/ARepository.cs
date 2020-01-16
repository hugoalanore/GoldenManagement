using DataAccessLayer.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public abstract class ARepository<T> : ICRUD<T>  where T : class
    {
        public T Create(T entity)
        {
            try
            {
                entity = DBContext.Instance.Set<T>().Add(entity);
                Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error on Create", e);
            }
            return entity;
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

        public T GetById(int id)
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

        public T Update(T entity)
        {
            try
            {
                entity = DBContext.Instance.Set<T>().Attach(entity);
                DBContext.Instance.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error on Update", e);
            }
            return entity;
        }

        public void Delete(int id)
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
