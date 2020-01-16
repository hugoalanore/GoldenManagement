using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Model.DataAccess
{
    class SimulBDD : IDataAccess
    {
        public Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur)
        {
            return new Utilisateur() { Id = 0, MotDePasse = "mdp", Nom = "Alanore", NomUtilisateur = "hugo", Prenom = "Hugo" };
        }

    }
}
