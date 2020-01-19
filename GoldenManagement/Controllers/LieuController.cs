using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers
{
    public class LieuController
    {
        #region Singleton
        private static readonly Lazy<LieuController> lazy = new Lazy<LieuController>(() => new LieuController());
        public static LieuController Instance { get { return lazy.Value; } }
        #endregion

        #region Constructeurs
        private LieuController()
        {
        }
        #endregion  
    }
}
