using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Ressources
{
    class ValidationAttribute
    {
        /// <summary>
        /// Vérifier la validité d’un champ de texte ou l’on entre une nom sous la forme "Abc" ou "Abc-abc".
        /// </summary>
        public class AlphaValidation : RegularExpressionAttribute
        {
            public AlphaValidation() : base(@"~[A-Z][a-z]*(-[A-Z][a-z]?)?~")
            { }
        }

        /// <summary>
        /// Vérifier la validité d’un champ de texte ou l’on entre une numeros de telephone sous la forme "00 00 00 00 00".
        /// </summary>
        public class TelephoneValidation : RegularExpressionAttribute
        {
            public TelephoneValidation() : base(@"^(0|\+33)[1-9]([-. ]?[0-9]{2}){4}$")
            { }
        }
        
        /// <summary>
        /// Vérifier la validité d’un champ de texte ou l’on entre une email sous la forme "abc123@cde456.aa" ou "abc123@cde456.aaa".
        /// </summary>
        public class EmailValidation : RegularExpressionAttribute
        {
            public EmailValidation() : base(@"^([\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+\.)*[\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$")
            { }
        }

        /// <summary>
        /// Vérifier la validité d’un champ de texte ou l’on entre une code postal sous la forme "00000".
        /// </summary>
        public class CodePostalValidation : RegularExpressionAttribute
        {
            public CodePostalValidation() : base(@"\^[0-9]{5,5}$\")
            { }
        }

        /// <summary>
        /// Vérifier la validité d’un champ de texte ou l’on entre une Pseudo sous la forme "abc123".
        /// </summary>
        public class PseudoValidation : RegularExpressionAttribute
        {
            public PseudoValidation() : base(@"\^[a-zA-Z0-9_]{3,16}$\")
            { }
        }
    }
}
