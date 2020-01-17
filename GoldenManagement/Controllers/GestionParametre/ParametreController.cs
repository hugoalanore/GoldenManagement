using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers.GestionParametre
{
    public class ParametreController
    {
        #region Singleton
        private static readonly Lazy<ParametreController> lazy = new Lazy<ParametreController>(() => new ParametreController());
        public static ParametreController Instance { get { return lazy.Value; } }
        #endregion

        #region Constructeurs
        private ParametreController()
        {
        }
        #endregion  
    }
}
