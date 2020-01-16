using GoldenManagement.Model;
using GoldenManagement.Model.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.BusinessLayer;
using DataAccessLayer.Models;

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
        #endregion


        #region Constructeurs
        private GoldenApp()
        {
            LivingData = new LivingData(); // Living Data

            // DataAccess = new SimulBDD(); // Data Access
            DataAccess = new DataAccessLayerBDD();       // Data Access
        }
        #endregion

        #region Gestion des utilisateurs
        public bool ConnexionApplication(string nomUtilisateur, string motDePasse)
        {
            if((nomUtilisateur != null && nomUtilisateur != String.Empty) && (motDePasse != null && motDePasse != String.Empty))
            {
                try
                {
                    Utilisateur utilisateur = DataAccess.GetUtilisateurByNomUtilisateur(nomUtilisateur);
                    if (utilisateur != null && utilisateur.MotDePasse == motDePasse)
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
        #endregion
    }
}