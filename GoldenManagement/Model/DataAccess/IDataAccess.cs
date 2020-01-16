using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace GoldenManagement.Model.DataAccess
{
    interface IDataAccess
    {
        #region Gestion des utilisateurs
        Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur);
        List<Utilisateur> GetAllUtilisateurs();
        List<String> GetAllRoleUtilisateur();
        bool AddUtilisateur(String prenom, String nom, String nomUtilisateur, String password, RoleUtilisateur role);
        bool DeleteUtilisateur(int id);
        Utilisateur GetUtilisateurById(int id);
        bool UpdateUtilisateur(String prenom, String nom, String nomUtilisateur, RoleUtilisateur role, int id);
        bool ResetPassWord(int id, String password);
        bool CheckNomUtilisateur(String nomUtilisateur);
        bool UpdatePassWord(int id, string password);
        #endregion

        #region Gestion des formations

        #endregion

        #region Gestion des personnes

        #endregion

        #region Gestion des lieux

        #endregion

        #region Gestion du matériel

        #endregion

        #region Planification

        #endregion
    }
}
