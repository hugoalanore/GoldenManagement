using DataAccessLayer.BusinessLayer;
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
            //Utilisateur utilisateur = new Utilisateur() { Nom = "a", Prenom = "b", NomUtilisateur = "c", MotDePasse = "d", Role = new RoleUtilisateur() { Designation = EEnum.ERoleUtilisateur.Dirigeant } };
            //Repository.Utilisateurs.Create(utilisateur);
            //Console.WriteLine(utilisateur.Id);
            //Console.WriteLine(Repository.Utilisateurs.GetById(utilisateur.Id).MotDePasse);
            //utilisateur.MotDePasse = "gioazejgbjkbeazkjgbaek";
            //Repository.Utilisateurs.Update(utilisateur);
            //Console.WriteLine(Repository.Utilisateurs.GetById(utilisateur.Id).MotDePasse);
            //Console.ReadLine();

            

            //Utilisateur utilisateur = Repository.Utilisateurs.GetAll().Where(u => u.NomUtilisateur == "prout").FirstOrDefault();
            // utilisateurs.ForEach(u => Console.WriteLine(u.NomUtilisateur));
            //Console.WriteLine(utilisateur.NomUtilisateur);
            //Console.ReadLine();
        }
    }
}
