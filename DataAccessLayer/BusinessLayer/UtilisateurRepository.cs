using DataAccessLayer.AccessLayer;
using DataAccessLayer.DataLayer;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Models;
using DataAccessLayer.Outiles.Log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.BusinessLayer
{
    public class UtilisateurRepository : ICRUD<Utilisateur>
    {
        public void Create(Utilisateur utilisateur)
        {
            try
            {
                DataMock.Instance.Utilisateurs.Add(utilisateur);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }
        }

        public void Update(Utilisateur utilisateur)
        {
            try
            {
                utilisateur.CopyPropertiesTo(DataMock.Instance.Utilisateurs.First(a => a.Id == utilisateur.Id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Update", e);
            }
        }

        public Utilisateur GetById(int id)
        {
            try
            {
                return DataMock.Instance.Utilisateurs.First(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public IEnumerable<Utilisateur> GetAll()
        {
            try
            {
                return DataMock.Instance.Utilisateurs;
            }
             catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public Utilisateur GetByNomUtilisateur(string nomUtilisateur)
        {
            try
            {
                return DataMock.Instance.Utilisateurs.FirstOrDefault(u => u.NomUtilisateur == nomUtilisateur);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e);
                throw new DALException("Error on GetByNomUtilisateur", e);
            }
        }

        public void Delete(int id)
        {
            try
            {
                DataMock.Instance.Utilisateurs.Remove(DataMock.Instance.Utilisateurs.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
