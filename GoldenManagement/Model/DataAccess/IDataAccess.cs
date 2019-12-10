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
        Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur);
        String GetPassWordByNomUtilisateur(string nomUtilisateur);
        #endregion

        #region Gestion des formations

        List<Formation> GetAllFormations();

        List<TypeFormation> GetAllFormationsTypes();

        Formation GetFormationById(int id);

        List<Formation> GetAllFormationByFormationType(int id);

        bool UpdateFormations(String intitule, int nbJour, String types, int id);

        bool AddFormations(String intitule, int nbJour, String types);

        bool DeleteFormation(int id);

        bool AddTypeFormations(String types);

        bool GetTypeFormationByType(String types);
        #endregion

        #region Gestion des personnes

        #endregion

        #region Gestion des lieux

        #endregion

        #region Gestion du matériel

        List<Materiel> GetAllMateriels();

        List<Materiel> GetListMaterielsFormation(int id);

        bool deleteMaterielFormation(int id);

        bool addMaterielFormation(int idFormation, string libelle, int quantite);
        #endregion


        #region Planification

        #endregion
    }
}
