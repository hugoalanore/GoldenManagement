using DataAccessLayer.Exceptions;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLayer
{
    public class RoleUtilisateurRepository : ARepository<RoleUtilisateur>
    {
        public RoleUtilisateur GetByDesignation(string designation)
        {
            try
            {
                return GetAll().ToList().Where(ru => ru.DesignationString == designation).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new DALException("Error on GetByDesignation", e);
            }
        }
    }
}
