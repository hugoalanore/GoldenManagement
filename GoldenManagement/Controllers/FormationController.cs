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

        public List<DomaineFormation> GetAllDomaineFormations()
        {
            return Repository.DomaineFormation.GetAll().ToList();
        }

        public Formation GetFormationById(int id)
        {
            Formation formation = Repository.Formation.GetById(id);
            formation.MaterielFormations = MaterielController.Instance.GetListMaterielsFormation(id);
            return formation;
        }

        public List<Formation> GetAllFormationsByDomaine(string designation)//TODO verif
        {
            return Repository.DomaineFormation.GetAllFormationByDomaine(designation).ToList();
        }

        public bool UpdateFormation(int id, DomaineFormation domaineFormation, int nbJour, string intitule)
        {
            if (intitule == string.Empty || domaineFormation == null || domaineFormation.Designation == string.Empty) { throw new ArgumentException("Les paramètres ne peuvent pas être vides."); }

            if (DomaineFormationExist(domaineFormation.Designation))
            {
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
            else
            {
                try
                {
                    AddDomaineFormation(domaineFormation.Designation);
                    Repository.Formation.UpdateById(id, intitule, nbJour, domaineFormation);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool AddFormation(string intitule, int nbJour, DomaineFormation domaineFormation)
        {
            if (intitule == string.Empty || domaineFormation == null || domaineFormation.Designation == string.Empty) { throw new ArgumentException("Les paramètres ne peuvent pas être vides."); }
            if (DomaineFormationExist(domaineFormation.Designation))
            {
                try
                {
                    Repository.Formation.Create(new Formation() { Intitule = intitule, NbJours = nbJour, Domaine = domaineFormation });
                    return true;
                }
                catch (Exception) { return false; }
            }
            else
            {
                try
                {
                    AddDomaineFormation(domaineFormation.Designation);
                    Repository.Formation.Create(new Formation() { Intitule = intitule, NbJours = nbJour, Domaine = domaineFormation });
                    return true;
                }
                catch (Exception) { return false; }
            }
        }

        public bool AddDomaineFormation(string designation)
        {
            if (designation == string.Empty) { throw new ArgumentException("La désignation du domaine ne peut pas être vides."); }

            if (DomaineFormationExist(designation))
            {
                return false;
            }
            else
            {
                try
                {
                    Repository.DomaineFormation.Create(new DomaineFormation() { Designation = designation });
                    return true;
                }
                catch (Exception) { return false; }
            }
        }

        public bool DeleteFormation(int id)
        {
            try { Repository.Formation.Delete(id); return true; }
            catch (Exception) { return false; }
        }

        public DomaineFormation GetDomaineFormationByDesignation(string designation)// TODO verif
        {
            return Repository.DomaineFormation.GetDomaineFormationByDesignation(designation);
        }

        public bool DomaineFormationExist(string designation)
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
        #endregion
    }
}
