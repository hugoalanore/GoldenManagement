using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controller.GestionUtilisateurs
{
    class UtilisateursController
    {
        #region Singleton
        private static readonly Lazy<UtilisateursController> lazy = new Lazy<UtilisateursController>(() => new UtilisateursController());
        public static UtilisateursController Instance { get { return lazy.Value; } }
        #endregion

        #region Propriétés
        private readonly GoldenApp _GA = GoldenApp.Instance;
        #endregion

        #region Constructeurs
        private UtilisateursController()
        {
        }
        #endregion

        #region Gestion des utilisateurs
        public List<Utilisateur> GetAllUtilsateurs()
        {
            return _GA.DataAccess.GetAllUtilisateurs();
        }

        public List<String> GetAllRoleUtilisateur()
        {
            return _GA.DataAccess.GetAllRoleUtilisateur();
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            return _GA.DataAccess.GetUtilisateurById(id);
        }

        public bool AddUtilisateur(String prenom, String nom, String nomUtilisateur, String password, RoleUtilisateur role)
        {
            if (_GA.DataAccess.CheckNomUtilisateur(nomUtilisateur))
            {
                return _GA.DataAccess.AddUtilisateur(prenom, nom, nomUtilisateur, password, role);
            }
            
            return false;
        }

        public bool DeleteUtilisateur(int id)
        {
            return _GA.DataAccess.DeleteUtilisateur(id);
        }

        public bool UpdateUtilisateur(String prenom, String nom, String nomUtilisateur, RoleUtilisateur role, int id)
        {
            return _GA.DataAccess.UpdateUtilisateur(prenom, nom, nomUtilisateur, role, id);
        }

        public bool ResetPassWord(int id)
        {
            return _GA.DataAccess.ResetPassWord(id, "pass");
        }

        public bool UpdatePassWord(int id, string actualPassword, string newPassword, string nomUtilisateur)
        {
            try
            {
                Utilisateur utilisateur = _GA.DataAccess.GetUtilisateurByNomUtilisateur(nomUtilisateur);

                String password = utilisateur.MotDePasse;
                if (actualPassword == password)
                {
                    return _GA.DataAccess.UpdatePassWord(id, newPassword);
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Les arguments passés en paramètre ne sont pas conformes", e);
            }
        }
        #endregion
    }
}
