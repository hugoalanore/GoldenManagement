using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("MATERIEL")]
    public class Materiel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Designation { get; set; }
        public bool EstActif { get; set; }
        public virtual ICollection<MaterielFormation> MaterielRequisFormations { get; set; }
        public virtual ICollection<StockMateriel> StockMateriels { get; set; }
    }
}
