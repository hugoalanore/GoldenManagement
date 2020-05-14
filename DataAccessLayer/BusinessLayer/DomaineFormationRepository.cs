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
    public class DomaineFormationRepository : ICRUD<DomaineFormation>
    {
        public DomaineFormation GetDomaineFormationByDesignation(string designation)
        {
            try
            {
                return GetAll().Where(dF => dF.Designation == designation).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetTypeFormationByDesignation", e);
            }
        }

        public ICollection<Formation> GetAllFormationByDomaine(string designation)
        {
            return GetDomaineFormationByDesignation(designation).Formations;
        }

        public IEnumerable<DomaineFormation> GetAll()
        {
            try
            {
                return DataMock.Instance.DomaineFormations;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public DomaineFormation GetById(int id)
        {
            try
            {
                return DataMock.Instance.DomaineFormations.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(DomaineFormation entity)
        {

            try
            {
                DataMock.Instance.DomaineFormations.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(DomaineFormation entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.DomaineFormations.First(a => a.Id == entity.Id));
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
                DataMock.Instance.DomaineFormations.Remove(DataMock.Instance.DomaineFormations.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
