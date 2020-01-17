using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Model.BusinessObjects
{
    public class Apprenant
    {
        public int Id { get; set; }
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DateNaissance { get; set; }
        public string LieuNaissance { get; set; }
        public string Nationnalite{ get; set; }
        public string Adresse{ get; set; }
        public string Ville{ get; set; }
        public string CodePostal{ get; set; }
        public string TelephonePortable{ get; set; }
        public string TelephoneFixe{ get; set; }
        public string Mail{ get; set; }
        public int EstActif { get; set; }

        public Apprenant() { }
    }
}
