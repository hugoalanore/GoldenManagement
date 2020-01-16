using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Ressources.ValidationAttribute;

namespace DataAccessLayer.Models
{
    [ComplexType]
    public class Adresse
    {
        [MinLength(5, ErrorMessage = "Le format du champ \"Rue\" est incorrecte!")]
        public string Rue { get; set; }

        [AlphaValidation(ErrorMessage = "Le format du champ \"Ville\" est incorrecte!")]
        public string Ville { get; set; }
        
        [CodePostalValidation(ErrorMessage = "Le format du champ \"Code Postal\" est incorrecte!")]
        public string CodePostal { get; set; }
    }
}
