using DataAccessLayer.AccessLayer;
using DataAccessLayer.Ressources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public abstract class ARepository<T> : ICRUD<T>  where T : class
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
                throw new Exception(string.Format(DAL.ErrorTransaction,"Create()" , this.GetType().Name), e);
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
                throw new Exception(string.Format(DAL.ErrorTransaction, "GetAll()", this.GetType().Name), e);
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
                throw new Exception(string.Format(DAL.ErrorTransaction, "GetByID()", this.GetType().Name), e);
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
                throw new Exception(string.Format(DAL.ErrorTransaction, "Update()", this.GetType().Name), e);
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
                throw new Exception(string.Format(DAL.ErrorTransaction, "Update()", this.GetType().Name), e);
            }
        }

        private void Save()
        {
            DBContext.Instance.SaveChanges();
        }
    }
}
