using GoldenManagement.Views.Application.Utilisateur;
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

namespace GoldenManagement.Views.Application.Parametre
{
    /// <summary>
    /// Logique d'interaction pour AccueilParametresPage.xaml
    /// </summary>
    public partial class AccueilParametrePage : Page
    {

        AccueilUtilisateurPage AccueilUtilisateursPage;
        AccueilMonProfilPage AccueilMonProfilPage;
        readonly MainWindow MainWindow;

        public AccueilParametrePage(MainWindow MainWindow)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
        }

        private void BTN_modifierProfil_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilMonProfilPage == null)
            {
                AccueilMonProfilPage = new AccueilMonProfilPage();
            }
            MainWindow.MainFrame.Content = AccueilMonProfilPage;
        }

        private void BTN_modifierServeurBDD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_modifierServeurMail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_gestionUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilUtilisateursPage == null)
            {
                AccueilUtilisateursPage = new AccueilUtilisateurPage(this.MainWindow);
            }
            MainWindow.MainFrame.Content = AccueilUtilisateursPage;
        }
    }
}
