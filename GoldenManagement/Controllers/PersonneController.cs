using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers
{
    public class PersonneController
    {
        #region Singleton
        private static readonly Lazy<PersonneController> lazy = new Lazy<PersonneController>(() => new PersonneController());
        public static PersonneController Instance { get { return lazy.Value; } }
        #endregion

        #region Constructeurs
        private PersonneController()
        {
            
        }
        #endregion

        #region Gestion des Formateurs
        public List<Formateur> GetAllFormateursFormations()
        {
            return null;
            //return _GA.DataAccess.GetAllFormateursFormations();  // TODO mettre a jour
        }

        public bool AddFormateurFormation(int idFormation, int idFormateur)
        {
            return false;
            //return _GA.DataAccess.AddFormateurFormation(idFormation, idFormateur);  // TODO mettre a jour
        }

        public bool DeleteFormateurFormation(int id)
        {
            return false;
            //return _GA.DataAccess.DeleteFormateurFormation(id);  // TODO mettre a jour
        }
        #endregion
    }
}
