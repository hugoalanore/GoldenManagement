using GoldenManagement.Model;
using GoldenManagement.Model.BusinessObjects;
using GoldenManagement.Model.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controller.GestionFormateurs
{
    class FormateursController
    {
        #region Singleton
        private static readonly Lazy<FormateursController> lazy = new Lazy<FormateursController>(() => new FormateursController());
        public static FormateursController Instance { get { return lazy.Value; } }
        #endregion

        #region Propriétés
        public IDataAccess DataAccess { get; set; } // La base de donnée
        public LivingData LivingData { get; set; } // La classe des données vivante de l'application
        #endregion

        #region Constructeurs
        private FormateursController()
        {
            LivingData = new LivingData(); // Living Data

            // DataAccess = new SimulBDD(); // Data Access
            DataAccess = new MySQL();       // Data Access
        }
        #endregion


        #region Gestion des Formateurs

        public List<Formateur> GetAllFormateursFormations()
        {
            return DataAccess.GetAllFormateursFormations();
        }

        public bool addFormateurFormation(int idFormation, int idFormateur)
        {
            return DataAccess.addFormateurFormation(idFormation, idFormateur);
        }

        public bool deleteFormateurFormation(int id)
        {
            return DataAccess.deleteFormateurFormation(id);
        }

        #endregion

    }
}
