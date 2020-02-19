using DataAccessLayer.BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers
{
    public class FormationController
    {
        #region Singleton
        private static readonly Lazy<FormationController> lazy = new Lazy<FormationController>(() => new FormationController());
        public static FormationController Instance { get { return lazy.Value; } }
        #endregion


        #region Constructeurs
        private FormationController()
        {
        }
        #endregion


        #region Les méthodes
        public List<Formation> GetAllFormations()
        {
            return Repository.Formation.GetAll().ToList();
        }

        public List<DomaineFormation> GetAllDomaineFormation()
        {
            return Repository.DomaineFormation.GetAll().ToList();
        }

        public Formation GetFormationById(int id)
        {
            Formation formation = Repository.Formation.GetById(id);
            formation.MaterielFormations = MaterielController.Instance.GetListMaterielsFormation(id);
            return formation;
        }

        public List<Formation> GetAllFormationByDomaine(string designation)//TODO verif
        {
            return Repository.DomaineFormation.GetAllFormationByDomaine(designation).ToList();
        }

        public bool UpdateFormation(int id, DomaineFormation domaineFormation, int nbJour, String intitule)
        {
            if (GetTypeFormationByType(domaineFormation.Designation))
            {
                return UpdateFormations(intitule, nbJour, domaineFormation, id);
            }
            else
            {
                AddTypeFormations(domaineFormation.Designation);
                return UpdateFormations(intitule, nbJour, domaineFormation, id);
            }
        }

        public bool UpdateFormations(string intitule, int nbJour, DomaineFormation domaineFormation, int id)//TODO verif
        {
            if (intitule == string.Empty || domaineFormation == null || domaineFormation.Designation == string.Empty) { throw new ArgumentException("Les paramètres ne peuvent pas être vides."); }

            try
            {
                Repository.Formation.UpdateById(id, intitule, nbJour, domaineFormation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddFormations(String intitule, int nbJour, DomaineFormation domaineFormation)
        {
            if (GetTypeFormationByType(domaineFormation.Designation))
            {
                return AddFormation(intitule, nbJour, domaineFormation);
            }
            else
            {
                AddTypeFormations(domaineFormation.Designation);
                return AddFormation(intitule, nbJour, domaineFormation);
            }
        }

        public bool AddFormation(string intitule, int nbJour, DomaineFormation domaineFormation)//TODO verif
        {
            if (intitule == string.Empty || domaineFormation == null || domaineFormation.Designation == string.Empty) { throw new ArgumentException("Les paramètres ne peuvent pas être vides."); }

            try
            {
                Repository.Formation.Create(new Formation() { Intitule = intitule, NbJours = nbJour, Domaine = domaineFormation });
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool DeleteFormation(int id)
        {
            try { Repository.Formation.Delete(id); return true; }
            catch (Exception) { return false; }
        }

        public bool AddTypeFormations(string libelle)
        {
            if (GetTypeFormationByType(libelle))
            {
                return false;
            }
            else
            {
                return AddTypeFormation(libelle);
            }
        }

        public bool AddTypeFormation(string designation)// TODO verif
        {
            if (designation == string.Empty) { throw new ArgumentException("Le type ne peuvent pas être vides."); }

            try
            {
                Repository.DomaineFormation.Create(new DomaineFormation() { Designation = designation });
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool GetTypeFormationByType(string designation)// TODO verif
        {
            try
            {
                Repository.DomaineFormation.GetDomaineFormationByDesignation(designation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DomaineFormation GetDomaineFormationByDesignation(string designation)// TODO verif
        {
            return Repository.DomaineFormation.GetDomaineFormationByDesignation(designation);
        }

        #endregion
    }
}
