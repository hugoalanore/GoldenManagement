using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Model.BusinessObjects
{
    class Materiel
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        //Dans table Materiels_Requis_Formation
        public int QuantiteFormation { get; set; }
        //Dans table Materiels_Stock_Salle
        public int QuantiteStock { get; set; }

        public Materiel() { }
    }
}
