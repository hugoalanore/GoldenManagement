﻿using GoldenManagement.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Model
{
    class LivingData
    {
        public LivingData() { }
        public int MyProperty { get; set; }
        public Utilisateur UtilisateurActif { get; set; }
    }
}
