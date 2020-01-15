using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [ComplexType]
    public class Adresse
    {
        public string Rue { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
    }
}
