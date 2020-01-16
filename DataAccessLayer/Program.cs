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
            Console.WriteLine("Start");
            List<TypeFormation> typesFormation = new List<TypeFormation>
            {
                new TypeFormation() { Designation = "Architecture"},
                new TypeFormation() { Designation = "Artisanat Bâtiment"},
                new TypeFormation() { Designation = "Droit - Justice"},
                new TypeFormation() { Designation = "Informatique"},
                new TypeFormation() { Designation = "Sport"},
            };
            typesFormation.ForEach(tf => Repository.TypeFormations.Create(tf));

            List<Formation> formations = new List<Formation>
            {
                new Formation() { Intitule = "Mastère Architecture Intérieure / Design", TypeFormation = typesFormation[0], NbJours = 5, EstActif = true},
                new Formation() { Intitule = "Mastère Design Global", TypeFormation = typesFormation[0], NbJours = 45, EstActif = true},

                new Formation() { Intitule = "CAP Tailleur de pierre", TypeFormation = typesFormation[1], NbJours = 100, EstActif = true},
                new Formation() { Intitule = "CAP Maçon", TypeFormation = typesFormation[1], NbJours = 77, EstActif = true},

                new Formation() { Intitule = "Master Droit et Gestion de la santé", TypeFormation = typesFormation[2], NbJours = 600, EstActif = true},
                new Formation() { Intitule = "Master 1 Droit des affaires", TypeFormation = typesFormation[2], NbJours = 35, EstActif = true},

                new Formation() { Intitule = "Master Administrateur Systèmes et Réseaux", TypeFormation = typesFormation[3], NbJours = 10, EstActif = true},
                new Formation() { Intitule = "Développeur WEB", TypeFormation = typesFormation[3], NbJours = 20, EstActif = true},

                new Formation() { Intitule = "Bachelor Management du sport", TypeFormation = typesFormation[4], NbJours = 60, EstActif = true},
                new Formation() { Intitule = "Bachelor 3 Commerce du sport", TypeFormation = typesFormation[4], NbJours = 420, EstActif = true},
            };
            formations.ForEach(f => Repository.Formations.Create(f));

            foreach (Formation f in Repository.Formations.GetAll())
            {
                Console.WriteLine(string.Format("- {0} durrée {1}", f.Intitule, f.NbJours.ToString()));
            }
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
