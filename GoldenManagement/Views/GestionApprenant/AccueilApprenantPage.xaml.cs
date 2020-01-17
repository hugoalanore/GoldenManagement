using DataAccessLayer.Models;
using GoldenManagement.Controllers;
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
    /// Logique d'interaction pour AccueilApprenantsPage.xaml
    /// </summary>
    public partial class AccueilApprenantPage : Page
    {
        private readonly ApprenantController _AC = ApprenantController.Instance;
        private List<Apprenant> apprenants = null;

        AjouterApprenantPage AjouterApprenantPage;
        private readonly MainWindow MainWindow;

        public AccueilApprenantPage(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            apprenants = _AC.GetAllApprenants();
            lvApprenants.ItemsSource = apprenants;
        }

        private void BTN_ajouter_apprenant_Click(object sender, RoutedEventArgs e)
        {
            if (AjouterApprenantPage == null)
            {
                AjouterApprenantPage = new AjouterApprenantPage(this.MainWindow, this);
            }
            MainWindow.MainFrame.Content = AjouterApprenantPage;
        }

        private void LvApprenantsColumnHeader_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_show_apprenant_Click(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
