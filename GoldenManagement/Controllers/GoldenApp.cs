using GoldenManagement.Models;
using GoldenManagement.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.BusinessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Chiffrement;

namespace GoldenManagement.Controllers
{
    class GoldenApp
    {
        #region Singleton
        private static readonly Lazy<GoldenApp> lazy = new Lazy<GoldenApp>(() => new GoldenApp());
        public static GoldenApp Instance { get { return lazy.Value; } }
        #endregion

        #region Propriétés
        public IDataAccess DataAccess { get; set; } // La base de donnée
        public LivingData LivingData { get; set; } // La classe des données vivante de l'application
        #endregion


        #region Constructeurs
        private GoldenApp()
        {
            LivingData = new LivingData(); // Living Data

            // DataAccess = new SimulBDD(); // Data Access
            DataAccess = new DataAccessLayerBDD();       // Data Access
        }
        #endregion

        #region Gestion des paramètres

        #endregion

        #region Gestion des utilisateurs
        public bool ConnexionApplication(string nomUtilisateur, string motDePasse)
        {
            if ((nomUtilisateur != null && nomUtilisateur != String.Empty) && (motDePasse != null && motDePasse != String.Empty))
            {
                try
                {
                    Utilisateur utilisateur = DataAccess.GetUtilisateurByNomUtilisateur(nomUtilisateur);
                    if (utilisateur != null && StringCipher.Decrypt(utilisateur.MotDePasse) == motDePasse)
                    {
                        LivingData.UtilisateurActif = utilisateur;
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
            return DataAccess.GetAllUtilisateurs();
        }

        public List<string> GetAllRoleUtilisateur()
        {
            return DataAccess.GetAllRoleUtilisateur();
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            return DataAccess.GetUtilisateurById(id);
        }

        public bool AddUtilisateur(string prenom, string nom, string nomUtilisateur, string password, RoleUtilisateur role)
        {
            if (!(DataAccess.ExistUtilisateur(nomUtilisateur)))
            {
                return DataAccess.AddUtilisateur(prenom, nom, nomUtilisateur, StringCipher.Encrypt(password), role);
            }

            return false;
        }

        public bool DeleteUtilisateur(int id)
        {
            return DataAccess.DeleteUtilisateur(id);
        }

        public bool UpdateUtilisateur(string prenom, string nom, RoleUtilisateur role, int id)
        {
            return DataAccess.UpdateUtilisateur(prenom, nom, role, id);
        }

        public bool ResetPassWord(int id)
        {
            return DataAccess.UpdateMotDePasse(id, StringCipher.Encrypt("pass"));
        }

        public bool UpdatePassWord(int id, string actualPassword, string newPassword, string nomUtilisateur)
        {
            try
            {
                Utilisateur utilisateur = DataAccess.GetUtilisateurByNomUtilisateur(nomUtilisateur);

                string password = StringCipher.Decrypt(utilisateur.MotDePasse);
                if (actualPassword == password)
                {
                    return DataAccess.UpdateMotDePasse(id, StringCipher.Encrypt(newPassword));
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