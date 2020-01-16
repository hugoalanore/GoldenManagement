using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required]
        [StringLength(50)]
        public string Intitule { get; set; }

        [Required]
        public int NbJours { get; set; }

        [DefaultValue("true")]
        public bool EstActif { get; set; }

        public TypeFormation TypeFormation { get; set; }

        public virtual ICollection<MaterielFormation> MaterielRequisFormation { get; set; }

        public virtual ICollection<FormationFormateur> FormationFormateur { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
