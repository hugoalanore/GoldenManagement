using DataAccessLayer.DataLayer;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public class JourRepository : ICRUD<Jour>
    {
        public IEnumerable<Jour> GetAll()
        {
            try
            {
                return DataMock.Instance.Jours;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public Jour GetById(int id)
        {
            try
            {
                return DataMock.Instance.Jours.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(Jour entity)
        {

            try
            {
                DataMock.Instance.Jours.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(Jour entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.Jours.First(a => a.Id == entity.Id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Update", e);
            }
        }

        public void Delete(int id)
        {
            try
            {
                DataMock.Instance.Jours.Remove(DataMock.Instance.Jours.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
