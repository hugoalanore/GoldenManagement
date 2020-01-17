using GoldenManagement.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Model.DataAccess
{
    class SimulBDD : IDataAccess
    {
        public List<Apprenant> GetApprenants()
        {
            throw new NotImplementedException();
        }

        public string GetPassWordByNomUtilisateur(string nomUtilisateur)
        {
            throw new NotImplementedException();
        }

        public Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur)
        {
            return new Utilisateur() { Id = 0, MotDePasse = "mdp", Nom = "Alanore", NomUtilisateur = "hugo", Prenom = "Hugo" };
        }

    }
}
