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
    public class BatimentRepository : ICRUD<Batiment>
    {
        public IEnumerable<Batiment> GetAll()
        {
            try
            {
                return DataMock.Instance.Batiments;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public Batiment GetById(int id)
        {
            try
            {
                return DataMock.Instance.Batiments.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(Batiment entity)
        {

            try
            {
                DataMock.Instance.Batiments.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(Batiment entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.Batiments.First(a => a.Id == entity.Id));
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
                DataMock.Instance.Batiments.Remove(DataMock.Instance.Batiments.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
