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
    }
}
