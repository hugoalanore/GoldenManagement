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
    }
}
