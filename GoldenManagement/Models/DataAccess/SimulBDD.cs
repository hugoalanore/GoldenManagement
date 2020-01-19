using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Models.DataAccess
{
    class SimulBDD : IDataAccess
    {
        public bool AddUtilisateur(string prenom, string nom, string nomUtilisateur, string motDePasse, RoleUtilisateur role)
        {
            throw new NotImplementedException();
        }

        public bool ExistUtilisateur(string nomUtilisateur)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUtilisateur(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllRoleUtilisateur()
        {
            throw new NotImplementedException();
        }

        public List<Utilisateur> GetAllUtilisateurs()
        {
            throw new NotImplementedException();
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            throw new NotImplementedException();
        }

        public Utilisateur GetUtilisateurByNomUtilisateur(string nomUtilisateur)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMotDePasse(int id, string motDePasse)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUtilisateur(string prenom, string nom, RoleUtilisateur role, int id)
        {
            throw new NotImplementedException();
        }
    }
}
