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
    public class FormateurRepository : ICRUD<Formateur>
    {
        public IEnumerable<Formateur> GetAll()
        {
            try
            {
                return DataMock.Instance.Formateurs;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public Formateur GetById(int id)
        {
            try
            {
                return DataMock.Instance.Formateurs.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(Formateur entity)
        {

            try
            {
                DataMock.Instance.Formateurs.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(Formateur entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.Formateurs.First(a => a.Id == entity.Id));
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
                DataMock.Instance.Formateurs.Remove(DataMock.Instance.Formateurs.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
