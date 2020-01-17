using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers.GestionUtilisateur
{
    public class UtilisateurController
    {
        #region Singleton
        private static readonly Lazy<UtilisateurController> lazy = new Lazy<UtilisateurController>(() => new UtilisateurController());
        public static UtilisateurController Instance { get { return lazy.Value; } }
        #endregion

        #region Propriétés
        private readonly GoldenApp _GA = GoldenApp.Instance;
        #endregion

        #region Constructeurs
        private UtilisateurController()
        {
        }
        #endregion

        #region Gestion des utilisateurs
        public bool ConnexionApplication(string nomUtilisateur, string motDePasse)
        {
            if ((nomUtilisateur != null && nomUtilisateur != String.Empty) && (motDePasse != null && motDePasse != String.Empty))
            {
                try
                {
                    Utilisateur utilisateur = _GA.DataAccess.GetUtilisateurByNomUtilisateur(nomUtilisateur);
                    if (utilisateur != null && utilisateur.MotDePasse == motDePasse)
                    {
                        _GA.LivingData.UtilisateurActif = utilisateur;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                // Les arguments ne sont pas correcte (nom d'utilisateur ou mot de passe vide)
                catch (ArgumentException e)
                {
                    throw new ArgumentException("Les arguments passés en paramètre ne sont pas conformes", e);
                }
            }
            else
            {
                throw new ArgumentException("Les arguments passés en paramètre ne sont pas conformes");
            }
        }

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
