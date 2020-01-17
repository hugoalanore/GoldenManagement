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
        public bool AddUtilisateur(string prenom, string nom, string nomUtilisateur, string password, RoleUtilisateur role)
        {
            throw new NotImplementedException();
        }

        public bool CheckNomUtilisateur(string nomUtilisateur)
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

        public bool ResetPassWord(int id, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassWord(int id, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUtilisateur(string prenom, string nom, string nomUtilisateur, RoleUtilisateur role, int id)
        {
            throw new NotImplementedException();
        }
    }
}
