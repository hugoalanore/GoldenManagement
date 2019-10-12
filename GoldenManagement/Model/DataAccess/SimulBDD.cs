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
        public Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur)
        {
            return new Utilisateur() { Id = 0, MotDePasse = "mdp", Nom = "Alanore", NomUtilisateur = "hugo", Prenom = "Hugo" };
        }

        public bool IsCorrectConnectionInformation(string nomUtilisateur, string motDePasse)
        {
            // Vérifier que les paramètres semblent correcte
            if (nomUtilisateur == String.Empty || motDePasse == String.Empty)
            {
                throw new ArgumentException();
            }

            if (nomUtilisateur == "" && motDePasse == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
