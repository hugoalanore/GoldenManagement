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
    public class StockMaterielRepository : ICRUD<StockMateriel>
    {

        public IEnumerable<StockMateriel> GetAll()
        {
            try
            {
                return DataMock.Instance.StockMateriels;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public StockMateriel GetById(int id)
        {
            try
            {
                return DataMock.Instance.StockMateriels.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(StockMateriel entity)
        {

            try
            {
                DataMock.Instance.StockMateriels.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(StockMateriel entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.StockMateriels.First(a => a.Id == entity.Id));
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
                DataMock.Instance.StockMateriels.Remove(DataMock.Instance.StockMateriels.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
