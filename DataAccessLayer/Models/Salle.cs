using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("SALLE")]
    public class Salle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool EstActif { get; set; }
        public String Designation { get; set; }
        public Batiment Batiment { get; set; }
        public virtual ICollection<StockMateriel> StockMateriels { get; set; }
    }
}
