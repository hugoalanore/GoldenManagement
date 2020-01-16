using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Models.EEnum;

namespace DataAccessLayer.Models
{
    [Table("ROLE_UTILISATEUR")]
    public class RoleUtilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ERoleUtilisateur Designation { get; set; }
    }
}
