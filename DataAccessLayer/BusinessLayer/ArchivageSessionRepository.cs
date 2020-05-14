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
    public class ArchivageSessionRepository : ICRUD<ArchivageSession>
    {
        public IEnumerable<ArchivageSession> GetAll()
        {
            try
            {
                return DataMock.Instance.ArchivageSessions;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public ArchivageSession GetById(int id)
        {
            try
            {
                return DataMock.Instance.ArchivageSessions.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(ArchivageSession entity)
        {

            try
            {
                DataMock.Instance.ArchivageSessions.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(ArchivageSession entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.ArchivageSessions.First(a => a.Id == entity.Id));
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
                DataMock.Instance.ArchivageSessions.Remove(DataMock.Instance.ArchivageSessions.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
