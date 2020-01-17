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
        public bool AddUtilisateur(string prenom, string nom, string nomUtilisateur, string password, RoleUtilisateur role)
        {
            if (prenom == String.Empty || nom == String.Empty || nomUtilisateur == String.Empty || password == String.Empty || role == null) { throw new ArgumentException("Les paramètres ne peuvent pas être vides."); }
            try
            {
                Repository.Utilisateurs.Create(new Utilisateur() { Nom = nom, Prenom = prenom, NomUtilisateur = nomUtilisateur, MotDePasse = password, Role = role });
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool CheckNomUtilisateur(string nomUtilisateur)
        {
            if (nomUtilisateur == String.Empty) { throw new ArgumentException("Le nom d'utilisateur ne peux pas être vide."); }
            return Repository.Utilisateurs.GetUtilisateurByNomUtilisateur(nomUtilisateur) != null ? true : false;
        }

        public bool DeleteUtilisateur(int id)
        {
            try { Repository.Utilisateurs.Delete(id); return true; }
            catch (Exception) { return false; }
        }

        public List<string> GetAllRoleUtilisateur()
        {
            List<string> roles = new List<string>();
            Repository.RoleUtilisateurs.GetAll().ToList().ForEach(r => roles.Add(r.Designation.ToString()));
            return roles;
        }

        public List<Utilisateur> GetAllUtilisateurs()
        {
            return Repository.Utilisateurs.GetAll().ToList();
        }

        public List<Apprenant> GetAllApprenants()
        {
            return Repository.Apprenants.GetAll().ToList();
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            return Repository.Utilisateurs.GetById(id);
        }

        public Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur)
        {
            if (nomUtilisateur == null || nomUtilisateur == String.Empty) { throw new ArgumentException("Le nom d'utilisateur ne peux pas être vide"); }
            return Repository.Utilisateurs.GetUtilisateurByNomUtilisateur(nomUtilisateur);
        }

        public bool ResetPassWord(int id, string password)
        {
            if (password == null || password == String.Empty) { throw new ArgumentException("Le mot de passe ne peux pas être vide"); }
            try
            {
                Utilisateur utilisateur = Repository.Utilisateurs.GetById(id);
                utilisateur.MotDePasse = password;
                Repository.Utilisateurs.Update(utilisateur);
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool UpdatePassWord(int id, string password)
        {
            if (password == null || password == String.Empty) { throw new ArgumentException("Le mot de passe ne peux pas être vide"); }
            try
            {
                Utilisateur utilisateur = Repository.Utilisateurs.GetById(id);
                utilisateur.MotDePasse = password;
                Repository.Utilisateurs.Update(utilisateur);
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool UpdateUtilisateur(string prenom, string nom, string nomUtilisateur, RoleUtilisateur role, int id)
        {
            if (prenom == String.Empty || nom == String.Empty || nomUtilisateur == String.Empty || role == null) { throw new ArgumentException("Les paramètres ne peuvent pas être vides."); }
            try
            {
                Repository.Utilisateurs.UpdateById(id, prenom, nom, role);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
