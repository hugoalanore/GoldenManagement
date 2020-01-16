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
            List<Adresse> adresses = new List<Adresse>
            {
                new Adresse(){ Rue = "A", Ville = "Pira8cicaba", CodePostal = "74h35" },
                new Adresse() { Rue = "6250 Enim, Chemin", Ville = "Schwedt", CodePostal = "91321" },
                new Adresse() { Rue = "747-2534 Non, Route", Ville = "Green Bay", CodePostal = "55562" },
                new Adresse() { Rue = "5334 Volutpat. Route", Ville = "Drachten", CodePostal = "91941" },
                new Adresse() { Rue = "CP 796, 8883 Leo. Impasse", Ville = "Champdani", CodePostal = "37156" },
            };

            List<Batiment> batiments = new List<Batiment>
            {
                new Batiment(){Designation = "Bâtiment 1", Adresse = adresses[0], Salles = null},
                new Batiment(){Designation = "Bâtiment 2", Adresse = adresses[1], Salles = null},
                new Batiment(){Designation = "Bâtiment 3", Adresse = adresses[2], Salles = null},
                new Batiment(){Designation = "Bâtiment 4", Adresse = adresses[3], Salles = null},
                new Batiment(){Designation = "Bâtiment 5", Adresse = adresses[4], Salles = null}
            };
            batiments.ForEach(b => Repository.Batiments.Create(b));
            Console.ReadLine();
        }
    }
}
