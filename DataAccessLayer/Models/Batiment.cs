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
    [Table("BATIMENT")]
    public class Batiment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DefaultValue("true")]
        public bool EstActif { get; set; }

        [Required]
        [StringLength(50)]
        public string Designation { get; set; }

        public Adresse Adresse { get; set; }

        public virtual ICollection<Salle> Salles { get; set; }
    }
}
