using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace GoldenManagement.Models.DataAccess
{
    interface IDataAccess
    {
        #region Gestion des utilisateurs
        Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur);
        List<Utilisateur> GetAllUtilisateurs();
        List<string> GetAllRoleUtilisateur();
        bool AddUtilisateur(string prenom, string nom, string nomUtilisateur, string motDePasse, RoleUtilisateur role);
        bool DeleteUtilisateur(int id);
        Utilisateur GetUtilisateurById(int id);
        bool UpdateUtilisateur(string prenom, string nom, RoleUtilisateur role, int id);
        bool ExistUtilisateur(string nomUtilisateur);
        bool UpdateMotDePasse(int id, string motDePasse);
        #endregion

        #region Gestion des formations

        #endregion

        #region Gestion des personnes

        #endregion

        #region Gestion des lieux

        #endregion

        #region Gestion du matériels

        #endregion

        #region Planification

        #endregion

        #region Facturation

        #endregion
    }
}
