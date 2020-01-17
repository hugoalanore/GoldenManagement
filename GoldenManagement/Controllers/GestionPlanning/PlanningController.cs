using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers.GestionPlanning
{
    public class PlanningController
    {
        #region Singleton
        private static readonly Lazy<PlanningController> lazy = new Lazy<PlanningController>(() => new PlanningController());
        public static PlanningController Instance { get { return lazy.Value; } }
        #endregion

        #region Constructeurs
        private PlanningController()
        {
        }
        #endregion
    }
}
