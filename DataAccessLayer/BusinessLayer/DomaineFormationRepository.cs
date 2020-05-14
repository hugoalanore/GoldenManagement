using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public class DomaineFormationRepository : ARepository<DomaineFormation>
    {
        public DomaineFormation GetDomaineFormationByDesignation(string designation)
        {
            try
            {
                return GetAll().Where(dF => dF.Designation == designation).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetTypeFormationByDesignation", e);
            }
        }

        public ICollection<Formation> GetAllFormationByDomaine(string designation)
        {
            return GetDomaineFormationByDesignation(designation).Formations;
        }
    }
}
