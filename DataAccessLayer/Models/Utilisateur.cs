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
    [Table("UTILISATEUR")]
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [AlphaValidation(ErrorMessage = "Le format du champ \"Prenom\" est incorrecte!")]
        public String Prenom { get; set; }

        [Required]
        [AlphaValidation(ErrorMessage = "Le format du champ \"Nom\" est incorrecte!")]
        public String Nom { get; set; }

        [Required]
        [PseudoValidation(ErrorMessage = "Le format du champ \"Nom utilisateur\" est incorrecte!")]
        public String NomUtilisateur { get; set; }

        [Required]
        [StringLength(50)]
        public String MotDePasse { get; set; }

        public RoleUtilisateur Role { get; set; }
    }
}
