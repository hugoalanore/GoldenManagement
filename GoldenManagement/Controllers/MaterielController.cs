using DataAccessLayer.BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers
{
    public class MaterielController
    {
        #region Singleton
        private static readonly Lazy<MaterielController> lazy = new Lazy<MaterielController>(() => new MaterielController());
        public static MaterielController Instance { get { return lazy.Value; } }
        #endregion


        #region Constructeurs
        private MaterielController()
        {
        }
        #endregion


        #region Méthodes
        public List<Materiel> GetAllMateriels()
        {
            return Repository.Materiel.GetAll().ToList();
        }

        public Materiel GetMaterielById(int id)
        {
            return Repository.Materiel.GetById(id);
        }

        public Materiel GetMaterielByLibelle(string designation)
        {
            if (designation == String.Empty) { throw new ArgumentException("Le libelle ne peuvent pas être vides."); }

            return Repository.Materiel.GetMaterielByLibelle(designation);
        }

        public List<MaterielFormation> GetListMaterielsFormation(int id)// TODO verif
        {
            return Repository.Formation.GetAllMaterielsByIdFormation(id).ToList();
        }

        public bool DeleteMaterielFormation(int id)// TODO verif
        {
            try { Repository.MaterielFormation.Delete(id); return true; }
            catch (Exception) { return false; }
        }

        public bool AddMaterielFormation(int idFormation, string designation, int quantite)// TODO verif
        {
            if (designation == String.Empty) { throw new ArgumentException("Le libelle ne peuvent pas être vides."); }

            try
            {
                Repository.MaterielFormation.Create(new MaterielFormation() { Formation = Repository.Formation.GetById(idFormation), Quantite = quantite, Materiel = GetMaterielByLibelle(designation) });
                
                return true;
            }
            catch (Exception) { return false; }
        }
        #endregion
    }
}
