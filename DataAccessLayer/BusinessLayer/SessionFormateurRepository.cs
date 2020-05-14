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
    public class SessionFormateurRepository : ICRUD<SessionFormateur>
    {

        public IEnumerable<SessionFormateur> GetAll()
        {
            try
            {
                return DataMock.Instance.SessionFormateurs;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public SessionFormateur GetById(int id)
        {
            try
            {
                return DataMock.Instance.SessionFormateurs.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(SessionFormateur entity)
        {

            try
            {
                DataMock.Instance.SessionFormateurs.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(SessionFormateur entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.SessionFormateurs.First(a => a.Id == entity.Id));
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
                DataMock.Instance.SessionFormateurs.Remove(DataMock.Instance.SessionFormateurs.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
