using DataAccessLayer.Chiffrement;
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
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string NomUtilisateur { get; set; }
        public string MotDePasse { get; set; }
        public RoleUtilisateur Role { get; set; }

        public Utilisateur() { }

        public Utilisateur Clone()
        {
            return new Utilisateur() { Id = Id, Prenom = Prenom, NomUtilisateur = NomUtilisateur, MotDePasse = MotDePasse, Role = Role };
        }
    }
}
