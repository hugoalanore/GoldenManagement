using DataAccessLayer.Ressources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Models.EEnum;
using static DataAccessLayer.Ressources.ValidationAttribute;

namespace DataAccessLayer.Models
{
    public abstract class APersonne
    {
        public ECivilite Civilite { get; set; } 

        [Required]
        [AlphaValidation(ErrorMessage = "Le format du champ \"Nom\" est incorrecte!")]
        public string Nom { get; set; }

        [Required]
        [AlphaValidation(ErrorMessage = "Le format du champ \"Prénom\" est incorrecte!")]
        public string Prenom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }

        [AlphaValidation(ErrorMessage = "Le format du champ \"Lieu de naissance\" est incorrecte!")]
        public string LieuNaissance { get; set; }

        [AlphaValidation(ErrorMessage = "Le format du champ \"Nationalité\" est incorrecte!")]
        public string Nationalite { get; set; }
        
        public Adresse Adresse { get; set; }

        [TelephoneValidation(ErrorMessage = "Le format du champ \"Numéros portable\" est incorrecte!")]
        public string NumeroPortable { get; set; }

        [TelephoneValidation(ErrorMessage = "Le format du champ \"Numéros domicile\" est incorrecte!")]
        public string NumeroDomicile { get; set; }

        [EmailValidation(ErrorMessage = "Le format du champ \"Adresse mail\" est incorrecte!")]
        public string AdresseMail { get; set; }
    }
}
