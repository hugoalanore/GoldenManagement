using log4net;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace GoldenManagement.Outils.Log4net
{
    public static class Logger
    {
        /// <summary>
        /// Permet d'appeler le logger de son choix puis la fonction correspondant au niveau de l'événement. ex: Log.info("Message Log...") 
        /// </summary>
        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }
}
