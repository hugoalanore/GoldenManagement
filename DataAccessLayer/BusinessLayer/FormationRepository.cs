using DataAccessLayer.AccessLayer;
using DataAccessLayer.DataLayer;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public class FormationRepository : ICRUD<Formation>
    {
        public new Formation GetById(int id)
        {
            try
            {
                Formation formation = DataMock.Instance.Formations.First(a => a.Id == id);
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
                return materielFormations;
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetAllMaterielsByIdFormation", e);
            }
        }


        public IEnumerable<Formation> GetAll()
        {
            try
            {
                return DataMock.Instance.Formations;
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetAll", e);
            }
        }

        public void Create(Formation entity)
        {

            try
            {
                DataMock.Instance.Formations.Add(entity);
            }
            catch (Exception e)
            {
                throw new DALException("Error on Create", e);
            }

        }

        public void Update(Formation entity)
        {
            try
            {
                entity.CopyPropertiesTo(DataMock.Instance.Formations.First(a => a.Id == entity.Id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Update", e);
            }
        }

        public void Delete(int id)
        {
            try
            {
                DataMock.Instance.Formations.Remove(DataMock.Instance.Formations.First(a => a.Id == id));
            }
            catch (Exception e)
            {
                throw new DALException("Error on Delete", e);
            }
        }
    }
}
