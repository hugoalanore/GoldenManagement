using GoldenManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.BusinessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Chiffrement;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DataAccessLayer.Enums;
using DataAccessLayer.Exceptions;
using GoldenManagement.Utiles.Log4net;
using log4net;
using System.Reflection;

namespace GoldenManagement.Controllers
{
    class GoldenApp : Logger, INotifyPropertyChanged
    {
        #region Singleton
        private static readonly Lazy<GoldenApp> lazy = new Lazy<GoldenApp>(() => new GoldenApp());
        public static GoldenApp Instance { get { return lazy.Value; } }
        #endregion


        #region Propriétés et collections
        // Application
        public ObservableCollection<Utilisateur> Utilisateurs { get { return new ObservableCollection<Utilisateur>(Repository.Utilisateur.GetAll()); } }
        // Lieu
        public ObservableCollection<Salle> Salles { get { return new ObservableCollection<Salle>(Repository.Salle.GetAll()); } }
        public ObservableCollection<Batiment> Batiments { get { return new ObservableCollection<Batiment>(Repository.Batiment.GetAll()); } }
        // Planning
        public ObservableCollection<Session> Sessions { get { return new ObservableCollection<Session>(Repository.Session.GetAll()); } }
        // Formation
        public ObservableCollection<Formation> Formations { get { return new ObservableCollection<Formation>(Repository.Formation.GetAll()); } }
        // Personne
        public ObservableCollection<Apprenant> Apprenants { get { return new ObservableCollection<Apprenant>(Repository.Apprenant.GetAll()); } }
        public ObservableCollection<Formateur> Formateurs { get { return new ObservableCollection<Formateur>(Repository.Formateur.GetAll()); } }
        // Bien
        public ObservableCollection<Materiel> Materiels { get { return new ObservableCollection<Materiel>(Repository.Materiel.GetAll()); } }
        // La classe des données vivante de l'application
        public LivingData LivingData { get; set; }

        public override ILog Log => throw new NotImplementedException();
        #endregion


        #region Constructeurs
        private GoldenApp()
        {
            LivingData = new LivingData(); // Living Data
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
                    Utilisateur utilisateur = Repository.Utilisateur.GetByNomUtilisateur(nomUtilisateur);
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
                    //
                    Log.Error("Les arguments passés en paramètre ne sont pas conformes : {0}",e);
                    throw new ArgumentException("Les arguments passés en paramètre ne sont pas conformes", e);
                }
            }
            else
            {
                //TODO: 
                Log.Error("Les arguments passés en paramètre ne sont pas conformes");
                throw new ArgumentException("Les arguments passés en paramètre ne sont pas conformes");
            }
        }

        //public List<string> GetAllRoleUtilisateur()
        //{
        //    List<string> roles = new List<string>();
        //    Repository.RoleUtilisateur.GetAll().ToList().ForEach(r => roles.Add(r.Designation.ToString()));
        //    return roles;
        //}

        public Utilisateur GetUtilisateurById(int id)
        {
            return Repository.Utilisateur.GetById(id);
        }

        public bool AddUtilisateur(string prenom, string nom, string nomUtilisateur, string password, RoleUtilisateur role)
        {
            if (nomUtilisateur == String.Empty) { throw new ArgumentException("Le nom d'utilisateur ne peux pas être vide."); }

            try
            {
                bool utilisateurExist = (Repository.Utilisateur.GetByNomUtilisateur(nomUtilisateur) != null) ? true : false;
                if (!utilisateurExist)
                {
                    Repository.Utilisateur.Create(new Utilisateur() { Prenom = prenom, Nom = nom, NomUtilisateur = nomUtilisateur, MotDePasse = StringCipher.Encrypt(password), Role = role });
                    CollectionChanged(EGoldenAppCollection.Utilisateurs);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUtilisateur(int id)
        {
            try
            {
                Repository.Utilisateur.Delete(id);
                CollectionChanged(EGoldenAppCollection.Utilisateurs);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
                CollectionChanged(EGoldenAppCollection.Utilisateurs);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ResetPassWord(int id)
        {
            try
            {
                Utilisateur utilisateur = Repository.Utilisateur.GetById(id);
                utilisateur.MotDePasse = StringCipher.Encrypt("pass");
                Repository.Utilisateur.Update(utilisateur);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePassWord(string actualPassword, string newPassword, int id)
        {
            try
            {
                Utilisateur utilisateur = Repository.Utilisateur.GetById(id);
                string password = StringCipher.Decrypt(utilisateur.MotDePasse);
                if (actualPassword == password)
                {
                    utilisateur.MotDePasse = StringCipher.Encrypt(newPassword);
                    Repository.Utilisateur.Update(utilisateur);
                    return true;
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

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        public void CollectionChanged(EGoldenAppCollection collectionName)
        { OnPropertyChanged(collectionName.ToString()); }
        #endregion
    }
}