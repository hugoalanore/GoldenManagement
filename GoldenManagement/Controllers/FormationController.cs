using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers
{
    public class FormationController
    {
        #region Singleton
        private static readonly Lazy<FormationController> lazy = new Lazy<FormationController>(() => new FormationController());
        public static FormationController Instance { get { return lazy.Value; } }
        #endregion

        #region Constructeurs
        private FormationController()
        {
        }
        #endregion  
    }
}
