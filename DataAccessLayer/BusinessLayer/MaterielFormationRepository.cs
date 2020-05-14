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
    public class MaterielFormationRepository : ICRUD<MaterielFormation>
    {
        public IEnumerable<MaterielFormation> GetAll()
        {
            try
            {
                return DataMock.Instance.MaterielFormations;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public MaterielFormation GetById(int id)
        {
            try
            {
                return DataMock.Instance.MaterielFormations.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(MaterielFormation entity)
        {

            try
            {
                DataMock.Instance.MaterielFormations.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(MaterielFormation entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.MaterielFormations.First(a => a.Id == entity.Id));
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
                DataMock.Instance.MaterielFormations.Remove(DataMock.Instance.MaterielFormations.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
