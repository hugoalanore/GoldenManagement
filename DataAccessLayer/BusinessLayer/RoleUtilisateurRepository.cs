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
    public class RoleUtilisateurRepository : ICRUD<RoleUtilisateur>
    {
        public RoleUtilisateur GetByDesignation(string designation)
        {
            try
            {
                return GetAll().ToList().Where(ru => ru.DesignationString == designation).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetByDesignation", e);
            }
        }

        public IEnumerable<RoleUtilisateur> GetAll()
        {
            try
            {
                return DataMock.Instance.RoleUtilisateurs;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public RoleUtilisateur GetById(int id)
        {
            try
            {
                return DataMock.Instance.RoleUtilisateurs.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void Create(RoleUtilisateur entity)
        {

            try
            {
                DataMock.Instance.RoleUtilisateurs.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(RoleUtilisateur entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.RoleUtilisateurs.First(a => a.Id == entity.Id));
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
                DataMock.Instance.RoleUtilisateurs.Remove(DataMock.Instance.RoleUtilisateurs.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
