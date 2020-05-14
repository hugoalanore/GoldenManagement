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
    public class FormationFormateurRepository : ICRUD<FormationFormateur>
    {
        public IEnumerable<FormationFormateur> GetAll()
        {
            try
            {
                return DataMock.Instance.FormationFormateurs;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public FormationFormateur GetById(int id)
        {
            try
            {
                return DataMock.Instance.FormationFormateurs.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(FormationFormateur entity)
        {

            try
            {
                DataMock.Instance.FormationFormateurs.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(FormationFormateur entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.FormationFormateurs.First(a => a.Id == entity.Id));
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
                DataMock.Instance.FormationFormateurs.Remove(DataMock.Instance.FormationFormateurs.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
