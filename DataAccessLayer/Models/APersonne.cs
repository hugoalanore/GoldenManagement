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
    public abstract class APersonne
    {
        public ECivilite Civilite { get; set; } 

        [StringLength(50, ErrorMessage = "Le Nom ne peux pas dépasser 50 caractères.")]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Prenom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }
        
        public string LieuNaissance { get; set; }
       
        public string Nationalite { get; set; }
        
        public Adresse Adresse { get; set; }
        
        public string NumeroPortable { get; set; }
        
        public string NumeroDomicile { get; set; }
        
        public string AdresseMail { get; set; }
    }
}
