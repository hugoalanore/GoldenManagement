using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controllers.GestionFormateur
{
    public class FormateurController
    {
        #region Singleton
        private static readonly Lazy<FormateurController> lazy = new Lazy<FormateurController>(() => new FormateurController());
        public static FormateurController Instance { get { return lazy.Value; } }
        #endregion

        #region Constructeurs
        private FormateurController()
        {
        }
        #endregion  
    }
}
