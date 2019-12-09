using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Model.BusinessObjects
{
    class Formation
    {
        public int Id { get; set; }
        public String Intitule { get; set; }
        public int NbJour { get; set; }
        //Dans table T_FORMATIONS_TYPES
        public String Libelle { get; set; }
        //Dans table T_GROUPE_MATERIELS_REQUIS_FORMATION & T_MATERIELS
        public List<Materiel> MaterielsFormation { get; set; }


        public Formation() { }
    }
}
