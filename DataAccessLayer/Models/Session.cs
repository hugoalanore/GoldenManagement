using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("SESSION")]
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Formation Formation { get; set; }

        public Salle Salle { get; set; }

        public virtual ICollection<JourSession> JourSessions { get; set; }
        
        public virtual ICollection<SessionApprenant> SessionApprenants { get; set; }

        public virtual ICollection<SessionFormateur> SessionFormateurs { get; set; }
    }
}
