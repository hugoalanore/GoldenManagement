using DataAccessLayer.AccessLayer;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public class FormationRepository : ARepository<Formation>
    {
        public new Formation GetById(int id)
        {
            try
            {
                Formation formation = DBContext.Instance.Formations.Find(id);
                DBContext.Instance.Entry(formation).Reference(f => f.Domaine).Load();
                return formation;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetById", e);
            }
        }

        public void UpdateById(int id, string intitule, int nbJour, DomaineFormation domaineFormation)
        {
            try
            {
                Formation formation = GetById(id);
                formation.Intitule = intitule;
                formation.NbJours = nbJour;
                formation.Domaine = domaineFormation;
                Update(formation);
            }
            catch (Exception e)
            {
                throw new Exception("Error on UpdateById", e);
            }
        }

        public ICollection<MaterielFormation> GetAllMaterielsByIdFormation(int id)
        {
            try
            {
                List<MaterielFormation> materielFormations = GetById(id).MaterielFormations.ToList();
                // List<Materiel> materiels = new List<Materiel>();
                // materielFormations.ForEach(mF => materiels.Add(mF.Materiel));
                return materielFormations;
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetAllMaterielsByIdFormation", e);
            }
        }
    }
}
