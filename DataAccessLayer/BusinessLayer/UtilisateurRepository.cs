using DataAccessLayer.AccessLayer;
using DataAccessLayer.Chiffrement;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Models;
using log4net;
using MySql.Data.MySqlClient;
using Outils.Log4net;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public class UtilisateurRepository : ARepository<Utilisateur>
    {
        public new void Create(Utilisateur utilisateur)
        {
            try
            {
                if(Repository.RoleUtilisateur.GetByDesignation(utilisateur.Role.DesignationString) != null)
                {
                    utilisateur.Role = Repository.RoleUtilisateur.GetByDesignation(utilisateur.Role.DesignationString);
                }
                DBContext.Instance.Utilisateurs.Add(utilisateur);
                Save();
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }
        }

        public new void Update(Utilisateur utilisateur)
        {
            try
            {
                if (Repository.RoleUtilisateur.GetByDesignation(utilisateur.Role.DesignationString) != null)
                {
                    RoleUtilisateur roleUtilisateur = DBContext.Instance.RoleUtilisateurs.Single(c => c.Id == Repository.RoleUtilisateur.GetByDesignation(utilisateur.Role.DesignationString).Id);
                    if (!utilisateur.Role.Equals(roleUtilisateur))
                    {
                        utilisateur.Role = roleUtilisateur;
                    }
                }
                DBContext.Instance.Entry(utilisateur).State = System.Data.Entity.EntityState.Modified;
                Save();
            }
            catch (Exception e)
            {
                throw new DALException("Error on Update", e);
            }
        }

        public new Utilisateur GetById(int id)
        {
            try
            {
                Utilisateur utilisateur = DBContext.Instance.Utilisateurs.Find(id);
                DBContext.Instance.Entry(utilisateur).Reference(u => u.Role).Load();
                return utilisateur;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public new ICollection<Utilisateur> GetAll()
        {
            try
            {
                ICollection<Utilisateur> utilisateurs = DBContext.Instance.Utilisateurs.ToList();
                utilisateurs.ToList().ForEach(util => DBContext.Instance.Entry(util).Reference(u => u.Role).Load());
                return utilisateurs;
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
               Logger.log.Info("It's works!!");
               return GetAll().Where(u => u.NomUtilisateur == nomUtilisateur).FirstOrDefault();
            }
            catch (Exception e)
            {
                //TODO Test log DAL
                Logger.Log.Error("Test Log DAL: Done");
                throw new DALException("Error on GetByNomUtilisateur", e);
            }
        }
    }
}
