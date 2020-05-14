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
    public class SessionApprenantRepository : ICRUD<SessionApprenant>
    {

        public IEnumerable<SessionApprenant> GetAll()
        {
            try
            {
                return DataMock.Instance.SessionApprenants;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public SessionApprenant GetById(int id)
        {
            try
            {
                return DataMock.Instance.SessionApprenants.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(SessionApprenant entity)
        {

            try
            {
                DataMock.Instance.SessionApprenants.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(SessionApprenant entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.SessionApprenants.First(a => a.Id == entity.Id));
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
                DataMock.Instance.SessionApprenants.Remove(DataMock.Instance.SessionApprenants.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
