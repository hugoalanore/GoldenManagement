using GoldenManagement.Controller;
using GoldenManagement.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoldenManagement.View.GestionApprenants
{
    /// <summary>
    /// Logique d'interaction pour AccueilApprenantsPage.xaml
    /// </summary>
    public partial class AccueilApprenantsPage : Page
    {
        GoldenApp _GA = GoldenApp.Instance; 

        public AccueilApprenantsPage()
        {
            InitializeComponent();
            RefreshDGV();
        }

        public void RefreshDGV()
        {
            //AllApprenants.Children.Remove();
            foreach (Apprenant apprenant in _GA.GetApprenants())
            {
                AllApprenants.Items.Add(apprenant);
            }
        }
       
    }
}
