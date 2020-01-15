using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("UTILISATEUR")]
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Prenom { get; set; }
        public String Nom { get; set; }
        public String NomUtilisateur { get; set; }
        public String MotDePasse { get; set; }
        public RoleUtilisateur Role { get; set; }
    }
}
