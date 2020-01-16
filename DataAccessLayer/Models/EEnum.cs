using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [ComplexType]
    public class EEnum
    {
        public enum ECivilite
        {
            Monsieur,
            Madame,
            Autre
        }

        public enum ERoleUtilisateur
        {
            Dirigeant,
            Secretaire,
            Comptable
        }
    }
}
