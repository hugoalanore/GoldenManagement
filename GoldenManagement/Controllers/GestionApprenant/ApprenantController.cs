using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers.GestionApprenant
{
    public class ApprenantController
    {
        #region Singleton
        private static readonly Lazy<ApprenantController> lazy = new Lazy<ApprenantController>(() => new ApprenantController());
        public static ApprenantController Instance { get { return lazy.Value; } }
        #endregion
        
        private readonly GoldenApp _GA = GoldenApp.Instance;
        #region Constructeurs
        private ApprenantController()
        {
        }
        #endregion

        public List<Apprenant> GetAllApprenants()
        {
            return _GA.DataAccess.GetAllApprenants();
        }
    }
}
