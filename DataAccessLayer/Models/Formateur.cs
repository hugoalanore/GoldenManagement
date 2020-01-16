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
    [Table("FORMATEUR")]
    public class Formateur : APersonne
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DefaultValue("true")]
        public bool EstActif { get; set; }
        
        public virtual ICollection<FormationFormateur> FormationFormateurs { get; set; }

        public virtual ICollection<SessionFormateur> SessionFormateurs { get; set; }
    }
}
