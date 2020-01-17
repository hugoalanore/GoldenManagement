using GoldenManagement.Controllers;
using GoldenManagement.Controllers.GestionUtilisateur;
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

namespace GoldenManagement.Views
{
    /// <summary>
    /// Logique d'interaction pour ConnexionWindow.xaml
    /// </summary>
    public partial class ConnexionWindow : Window
    {
        private readonly UtilisateurController _UC = UtilisateurController.Instance;

        // Déplacer la fenêtre
        private void CZ_appBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        public ConnexionWindow()
        {
            InitializeComponent();
        }

        private void BTN_seConnecter_Click(object sender, RoutedEventArgs e)
        {
            string nomUtilisateur = TB_nomUtilisateur.Text;
            string motDePasse = PB_motDePasse.Password;

            try
            {
                if (_UC.ConnexionApplication(nomUtilisateur, motDePasse))
                {
                    TB_connexionResultat.Text = String.Empty;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
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

        private void BTN_minimiser_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BTN_fermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
