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
    public class JourSessionRepository : ICRUD<JourSession>
    {
        public IEnumerable<JourSession> GetAll()
        {
            try
            {
                return DataMock.Instance.JourSessions;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public JourSession GetById(int id)
        {
            try
            {
                return DataMock.Instance.JourSessions.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(JourSession entity)
        {

            try
            {
                DataMock.Instance.JourSessions.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(JourSession entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.JourSessions.First(a => a.Id == entity.Id));
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
                DataMock.Instance.JourSessions.Remove(DataMock.Instance.JourSessions.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
