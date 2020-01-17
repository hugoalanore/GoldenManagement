using GoldenManagement.Model.BusinessObjects;
using GoldenManagement.Model.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenManagement.Controller.GestionApprenants
{
    public class ApprenantController
    {
        // Constructeur
        public ApprenantController() {}

        public List<Apprenant> GetApprenants(IDataAccess dataAccess)
        {
            return dataAccess.GetApprenants();
        }
    }
}
