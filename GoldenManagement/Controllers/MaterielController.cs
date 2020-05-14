using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers
{
    public class MaterielController
    {
        #region Singleton
        private static readonly Lazy<MaterielController> lazy = new Lazy<MaterielController>(() => new MaterielController());
        public static MaterielController Instance { get { return lazy.Value; } }
        #endregion

        #region Constructeurs
        private MaterielController()
        {
        }
        #endregion  
    }
}
