using GoldenManagement.Model;
using GoldenManagement.Model.BusinessObjects;
using GoldenManagement.Model.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controller.GestionMateriels
{
    class MaterielsController
    {
        #region Singleton
        private static readonly Lazy<MaterielsController> lazy = new Lazy<MaterielsController>(() => new MaterielsController());
        public static MaterielsController Instance { get { return lazy.Value; } }
        #endregion

        #region Propriétés
        public IDataAccess DataAccess { get; set; } // La base de donnée
        public LivingData LivingData { get; set; } // La classe des données vivante de l'application
        #endregion

        #region Constructeurs
        private MaterielsController()
        {
            LivingData = new LivingData(); // Living Data

            // DataAccess = new SimulBDD(); // Data Access
            DataAccess = new MySQL();       // Data Access
        }
        #endregion

        #region Gestion du Materiels

        public List<Materiel> GetAllMateriels()
        {
            return DataAccess.GetAllMateriels();
        }

        public bool addMaterielFormation(int idFormation, string libelle, int quantite)
        {
            return DataAccess.addMaterielFormation(idFormation, libelle, quantite);
        }

        public bool deleteMaterielFormation(int id)
        {
            return DataAccess.deleteMaterielFormation(id);
        }
        #endregion
    }
}
