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
    [Table("APPRENANT")]
    public class Apprenant : APersonne
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DefaultValue("true")]
        public bool EstActif { get; set; }

        public virtual ICollection<SessionApprenant> SessionApprenants { get; set; }
    }
}
