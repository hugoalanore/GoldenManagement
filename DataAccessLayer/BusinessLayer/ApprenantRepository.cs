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
    public class ApprenantRepository : ICRUD<Apprenant>
    {
        public IEnumerable<Apprenant> GetAll()
        {
            try
            {
                return DataMock.Instance.Apprenants;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e); //sfgdsfs
            }
        }

        public Apprenant GetById(int id)
        {
            try
            {
                return DataMock.Instance.Apprenants.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(Apprenant entity)
        {
            
            try
            {
                DataMock.Instance.Apprenants.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(Apprenant entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.Apprenants.First(a => a.Id == entity.Id));
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
                DataMock.Instance.Apprenants.Remove(DataMock.Instance.Apprenants.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }

    }
}
