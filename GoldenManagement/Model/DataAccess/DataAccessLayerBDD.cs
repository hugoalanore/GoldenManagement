using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.BusinessLayer;
using DataAccessLayer.Models;

namespace GoldenManagement.Model.DataAccess
{
    public class DataAccessLayerBDD : IDataAccess
    {
        public Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur)
        {
            if(nomUtilisateur == null || nomUtilisateur == String.Empty)
            {
                throw new ArgumentException("Le nom d'utilisateur ne peux pas être vide");
            }
            return Repository.Utilisateurs.GetUtilisateurByNomUtilisateur(nomUtilisateur);
        }
    }
}
