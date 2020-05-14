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
    public class SalleRepository : ICRUD<Salle>
    {

        public IEnumerable<Salle> GetAll()
        {
            try
            {
                return DataMock.Instance.Salles;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public Salle GetById(int id)
        {
            try
            {
                return DataMock.Instance.Salles.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(Salle entity)
        {

            try
            {
                DataMock.Instance.Salles.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(Salle entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.Salles.First(a => a.Id == entity.Id));
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
                DataMock.Instance.Salles.Remove(DataMock.Instance.Salles.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
