using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers
{
    #region Singleton
    class FacturationController
    {
        private static readonly Lazy<FacturationController> lazy = new Lazy<FacturationController>(() => new FacturationController());
        public static FacturationController Instance { get { return lazy.Value; } }
        #endregion

        #region Constructeurs
        private FacturationController()
        {
        }
        #endregion
    }
}
