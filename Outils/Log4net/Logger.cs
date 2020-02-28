using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Outils.Log4net
{
    public class Logger
    {
        /// <summary>
        /// Permet d'appeler le logger de son choix puis la fonction correspondant au niveau de l'événement. ex: Log.info("Message Log...") 
        /// </summary>
        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }
}
