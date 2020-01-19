using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.BusinessLayer;
using DataAccessLayer.Models;

namespace GoldenManagement.Models.DataAccess
{
    public class DataAccessLayerBDD : IDataAccess
    {
        #region Gestion des utilisateurs
        public bool AddUtilisateur(string prenom, string nom, string nomUtilisateur, string motDePasse, RoleUtilisateur role)
        {
            if (prenom == String.Empty || nom == String.Empty || nomUtilisateur == String.Empty || motDePasse == String.Empty || role == null) { throw new ArgumentException("Les paramètres ne peuvent pas être vides."); }
            try
            {
                Repository.Utilisateur.Create(new Utilisateur() { Nom = nom, Prenom = prenom, NomUtilisateur = nomUtilisateur, MotDePasse = motDePasse, Role = role });
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool ExistUtilisateur(string nomUtilisateur)
        {
            if (nomUtilisateur == String.Empty) { throw new ArgumentException("Le nom d'utilisateur ne peux pas être vide."); }
            return (Repository.Utilisateur.GetByNomUtilisateur(nomUtilisateur) != null) ? true : false;
        }

        public bool DeleteUtilisateur(int id)
        {
            try { Repository.Utilisateur.Delete(id); return true; }
            catch (Exception) { return false; }
        }

        public List<string> GetAllRoleUtilisateur()
        {
            List<string> roles = new List<string>();
            Repository.RoleUtilisateur.GetAll().ToList().ForEach(r => roles.Add(r.Designation.ToString()));
            return roles;
        }

        public List<Utilisateur> GetAllUtilisateurs()
        {
            return Repository.Utilisateur.GetAll().ToList();
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            return Repository.Utilisateur.GetById(id);
        }

        public Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur)
        {
            if (nomUtilisateur == null || nomUtilisateur == String.Empty) { throw new ArgumentException("Le nom d'utilisateur ne peux pas être vide"); }
            return Repository.Utilisateur.GetByNomUtilisateur(nomUtilisateur);
        }

        public bool UpdateMotDePasse(int id, string motDePasse)
        {
            if (motDePasse == null || motDePasse == String.Empty) { throw new ArgumentException("Le mot de passe ne peux pas être vide"); }
            try
            {
                Utilisateur utilisateur = Repository.Utilisateur.GetById(id);
                utilisateur.MotDePasse = motDePasse;
                Repository.Utilisateur.Update(utilisateur);
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool UpdateUtilisateur(string prenom, string nom, RoleUtilisateur role, int id)
        {
            if (prenom == null || prenom == String.Empty || nom == null || nom == String.Empty || role == null) { throw new ArgumentException("Les paramètres ne peuvent pas être vides."); }
            try
            {
                Utilisateur utilisateur = Repository.Utilisateur.GetById(id);
                utilisateur.Prenom = prenom;
                utilisateur.Nom = nom;
                utilisateur.Role = role;
                Repository.Utilisateur.Update(utilisateur);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Gestion des formations

        #endregion

        #region Gestion des personnes

        #endregion

        #region Gestion des lieux

        #endregion

        #region Gestion du matériels

        #endregion

        #region Planification

        #endregion

        #region Facturation

        #endregion
    }
}
