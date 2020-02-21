using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch =true)]

namespace GoldenManagement.Utiles.Log4net
{
    abstract class Logger
    {
        /// <summary>
        /// Affecter la valeur "LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);" à la variable ILog log
        /// </summary>
        public abstract ILog Log { get; }
    }
}
