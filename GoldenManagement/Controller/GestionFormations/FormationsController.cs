using GoldenManagement.Model;
using GoldenManagement.Model.BusinessObjects;
using GoldenManagement.Model.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controller.GestionFormations
{
    class FormationsController
    {
        #region Singleton
        private static readonly Lazy<FormationsController> lazy = new Lazy<FormationsController>(() => new FormationsController());
        public static FormationsController Instance { get { return lazy.Value; } }
        #endregion

        #region Propriétés
        public IDataAccess DataAccess { get; set; } // La base de donnée
        public LivingData LivingData { get; set; } // La classe des données vivante de l'application
        #endregion

        #region Constructeurs
        private FormationsController()
        {
            LivingData = new LivingData(); // Living Data

            // DataAccess = new SimulBDD(); // Data Access
            DataAccess = new MySQL();       // Data Access
        }
        #endregion

        #region Gestion des Formations

        public List<Formation> GetAllFormations()
        {
            return DataAccess.GetAllFormations();
        }

        public List<TypeFormation> GetAllFormationsTypes()
        {
            return DataAccess.GetAllFormationsTypes();
        }

        public Formation GetFormationById(int id)
        {
            Formation formation = DataAccess.GetFormationById(id);
            formation.MaterielsFormation = DataAccess.GetListMaterielsFormation(id);
            return formation;
        }

        public List<Formation> GetAllFormationByFormationType(int id)
        {
            return DataAccess.GetAllFormationByFormationType(id);
        }

        public bool UpdateFormation(int id, string libelle, int nbJour, String intitule)
        {
            if (DataAccess.GetTypeFormationByType(libelle))
            {
                return DataAccess.UpdateFormations(intitule, nbJour, libelle, id);
            }
            else
            {
                DataAccess.AddTypeFormations(libelle);
                return DataAccess.UpdateFormations(intitule, nbJour, libelle, id);
            }
        }

        public bool DeleteFormation(int id)
        {
            return DataAccess.DeleteFormation(id);
        }

        public bool AddFormations(String intitule, int nbJour, String libelle)
        {
            if (DataAccess.GetTypeFormationByType(libelle))
            {
                return DataAccess.AddFormations(intitule, nbJour, libelle);
            }
            else
            {
                DataAccess.AddTypeFormations(libelle);
                return DataAccess.AddFormations(intitule, nbJour, libelle);
            }
        }
        #endregion
    }
}
