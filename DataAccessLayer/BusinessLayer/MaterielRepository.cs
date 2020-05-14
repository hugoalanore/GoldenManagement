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
    public class MaterielRepository : ICRUD<Materiel>
    {
        public Materiel GetMaterielByLibelle(string designation)
        {
            try
            {
                return GetAll().Where(m => m.Designation == designation).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetTypeFormationByDesignation", e);
            }
        }

        public IEnumerable<Materiel> GetAll()
        {
            try
            {
                return DataMock.Instance.Materiels;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public Materiel GetById(int id)
        {
            try
            {
                return DataMock.Instance.Materiels.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(Materiel entity)
        {

            try
            {
                DataMock.Instance.Materiels.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(Materiel entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.Materiels.First(a => a.Id == entity.Id));
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
                DataMock.Instance.Materiels.Remove(DataMock.Instance.Materiels.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
