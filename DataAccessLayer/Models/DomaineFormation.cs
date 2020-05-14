using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("DOMAINE_FORMATION")]
    public class DomaineFormation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool EstActif { get; set; }
        public string Designation { get; set; }
        public virtual ICollection<Formation> Formations { get; set; }

        public override string ToString()
        {
            return Designation;
        }
    }
}
