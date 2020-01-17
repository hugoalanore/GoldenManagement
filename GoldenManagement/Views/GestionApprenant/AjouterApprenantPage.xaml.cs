using DataAccessLayer.Models;
using GoldenManagement.Controllers.GestionApprenant;
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

namespace GoldenManagement.Views.GestionApprenant
{
    /// <summary>
    /// Logique d'interaction pour AjouterApprenantPage.xaml
    /// </summary>
    public partial class AjouterApprenantPage : Page
    {
        private readonly ApprenantController _AC = ApprenantController.Instance;
        private List<Apprenant> apprenants = null;

        AccueilApprenantPage AccueilApprenantPage;
        readonly MainWindow MainWindow;

        public AjouterApprenantPage(MainWindow MainWindow, AccueilApprenantPage AccueilApprenantPage)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            this.AccueilApprenantPage = AccueilApprenantPage;

        }

    }
}
