using GoldenManagement.Controller;
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
using System.Windows.Shapes;

namespace GoldenManagement.View
{
    /// <summary>
    /// Logique d'interaction pour ConnexionWindow.xaml
    /// </summary>
    public partial class ConnexionWindow : Window
    {
        private readonly GoldenApp _GA = GoldenApp.Instance;

        // Déplacer la fenêtre
        private void R_appBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        public ConnexionWindow()
        {
            InitializeComponent();
            // Centre la fenêtre à l'écran
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void BTN_seConnecter_Click(object sender, RoutedEventArgs e)
        {
            string nomUtilisateur = TB_nomUtilisateur.Text;
            string motDePasse = PB_motDePasse.Password;

            try
            {
                if (_GA.ConnexionApplication(nomUtilisateur, motDePasse))
                {
                    TB_connexionResultat.Text = String.Empty;
                    this.Close();
                    DashboardWindow dashboardWindow = new DashboardWindow();
                    dashboardWindow.ShowDialog();
                }
                else
                {
                    TB_connexionResultat.Text = "Connexion échoué.";
                    PB_motDePasse.Password = String.Empty;
                }
            }
            catch (ArgumentException)
            {
                TB_connexionResultat.Text = "Vous devez remplir toutes les zones de texte !";
            }
        }

        private void BTN_quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTN_reduce_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
