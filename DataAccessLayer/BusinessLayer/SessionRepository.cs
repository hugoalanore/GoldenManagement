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
    public class SessionRepository : ICRUD<Session>
    {

        public IEnumerable<Session> GetAll()
        {
            try
            {
                return DataMock.Instance.Sessions;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public Session GetById(int id)
        {
            try
            {
                return DataMock.Instance.Sessions.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(Session entity)
        {

            try
            {
                DataMock.Instance.Sessions.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(Session entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.Sessions.First(a => a.Id == entity.Id));
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
                DataMock.Instance.Sessions.Remove(DataMock.Instance.Sessions.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
