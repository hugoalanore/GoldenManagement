using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("FORMATION")]
    public class Formation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Intitule { get; set; }
        public int NbJours { get; set; }
        public bool EstActif { get; set; }
        public DomaineFormation Domaine { get; set; }
        public virtual ICollection<MaterielFormation> MaterielFormations { get; set; }
        public virtual ICollection<FormationFormateur> FormationFormateurs { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
