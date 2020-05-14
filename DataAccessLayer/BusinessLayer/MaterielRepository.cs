using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public class MaterielRepository : ARepository<Materiel>
    {
        public Materiel GetMaterielByLibelle(string designation)
        {
            try
            {
                return GetAll().Where(m => m.Designation == designation).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetTypeFormationByDesignation", e);
            }
        }
    }
}
