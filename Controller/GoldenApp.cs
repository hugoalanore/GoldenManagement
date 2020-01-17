using GoldenManagement.Model;
using GoldenManagement.Model.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldenManagement.Controller.Securite;
using GoldenManagement.Model.BusinessObjects;
using GoldenManagement.Controller.GestionApprenants;

namespace GoldenManagement.Controller
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
        private ApprenantController ApprenantController { get; set; }
        #endregion


        #region Constructeurs
        private GoldenApp()
        {
            LivingData = new LivingData(); // Living Data

            // DataAccess = new SimulBDD(); // Data Access
            DataAccess = new MySQL();       // Data Access
            ApprenantController = new ApprenantController();
        }
        #endregion

        #region Gestion des utilisateurs
        public bool ConnexionApplication(string nomUtilisateur, string motDePasse)
        {
            try
            {
                // Si les informations sont correctes
                String password = StringCipher.Decrypt(DataAccess.GetPassWordByNomUtilisateur(nomUtilisateur));

                if (password == motDePasse)
                {
                    LivingData.UtilisateurActif = DataAccess.GetUtilisateurByNomUtilisateur(nomUtilisateur);
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
        #endregion

        #region Gestion des personnes
        public List<Apprenant> GetApprenants()
        {
            return ApprenantController.GetApprenants(DataAccess);
        }
        #endregion
    }
}