using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Enums;

namespace DataAccessLayer.Models
{
    [Table("ROLE_UTILISATEUR")]
    public class RoleUtilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotMapped]
        public ERoleUtilisateur Designation { get; set; }

        [Column("Designation")]
        public string DesignationString {
            get { return Designation.ToString(); }
            set { Designation = value.ToEnum<ERoleUtilisateur>(); }
        }

        public override string ToString()
        {
            return Designation.ToString();
        }
    }
}
