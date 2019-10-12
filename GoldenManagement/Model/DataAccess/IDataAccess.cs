using GoldenManagement.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Model.DataAccess
{
    interface IDataAccess
    {
        #region Gestion des utilisateurs
        // Gestion des utilisateurs
        bool IsCorrectConnectionInformation(string nomUtilisateur, string motDePasse);
        Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur);
        #endregion

        #region Gestion des entités

        #endregion

        #region Planification

        #endregion
    }
}
