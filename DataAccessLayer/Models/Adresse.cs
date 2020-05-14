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
        [Column("Rue")]
        public string Rue { get; set; }
        [Column("Ville")]
        public string Ville { get; set; }
        [Column("CodePostal")]
        public string CodePostal { get; set; }
    }
}
