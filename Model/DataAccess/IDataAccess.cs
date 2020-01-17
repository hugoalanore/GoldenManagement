using GoldenManagement.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Model.DataAccess
{
    public interface IDataAccess
    {
        #region Gestion des utilisateurs
        // Gestion des utilisateurs
        Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur);
        String GetPassWordByNomUtilisateur(string nomUtilisateur);
        #endregion

        #region Gestion des formations

        #endregion

        #region Gestion des personnes
        List<Apprenant> GetApprenants();
        #endregion

        #region Gestion des lieux

        #endregion

        #region Gestion du matériel

        #endregion

        #region Planification

        #endregion
    }
}
