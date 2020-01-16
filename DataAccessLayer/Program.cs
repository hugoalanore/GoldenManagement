using DataAccessLayer.BusinessLayer;
using DataAccessLayer.Chiffrement;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Utilisateur DB_MYSQL_RMS = new Utilisateur() { Nom = "DB_MYSQL_RMS", Prenom = "DB_MYSQL_RMS", NomUtilisateur = "DB_MYSQL_RMS", MotDePasse = "server=remotemysql.com;uid=PjQyjbDZNh;database=PjQyjbDZNh;password=GXvAQzDbsS;port=3306;persistsecurityinfo=True;", Role = new RoleUtilisateur() { Designation = EEnum.ERoleUtilisateur.Comptable } };
            //Utilisateur DB_MYSQL_LOCAL_ADMIN = new Utilisateur() { Nom = "DB_MYSQL_LOCAL_ADMIN", Prenom = "DB_MYSQL_LOCAL_ADMIN", NomUtilisateur = "DB_MYSQL_LOCAL_ADMIN", MotDePasse = "server=localhost;uid=hugo;database=goldendb;password=SuperP@ss;port=3306;persistsecurityinfo=True;", Role = new RoleUtilisateur() { Designation = EEnum.ERoleUtilisateur.Comptable } };
            //Utilisateur DB_MYSQL_LOCAL_GUDB = new Utilisateur() { Nom = "DB_MYSQL_LOCAL_GUDB", Prenom = "DB_MYSQL_LOCAL_GUDB", NomUtilisateur = "DB_MYSQL_LOCAL_GUDB", MotDePasse = "server=localhost;uid=goldenuserdb;database=goldendb;password=GoldenP4ss;port=3306;persistsecurityinfo=True;", Role = new RoleUtilisateur() { Designation = EEnum.ERoleUtilisateur.Comptable } };

            //Repository.Utilisateurs.Create(DB_MYSQL_RMS);
            //Repository.Utilisateurs.Create(DB_MYSQL_LOCAL_ADMIN);
            //Repository.Utilisateurs.Create(DB_MYSQL_LOCAL_GUDB);

            Utilisateur utilisateur = new Utilisateur() { Prenom = "CD", Nom = "CD", MotDePasse = "CD", NomUtilisateur = "CD", Role = new RoleUtilisateur() { Designation = EEnum.ERoleUtilisateur.Comptable } };
            Repository.Utilisateurs.Create(utilisateur);
        }
    }
}
