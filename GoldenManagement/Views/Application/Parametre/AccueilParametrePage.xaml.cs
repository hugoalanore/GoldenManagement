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
        private AccueilUtilisateurPage accueilUtilisateursPage = null;
        private AccueilMonProfilPage accueilMonProfilPage = null;
        private AccueilBDDParametrePage accueilBDDParametrePage = null;
        private AccueilMailParametrePage accueilMailParametrePage = null;

        public AccueilParametrePage()
        {
            InitializeComponent();
        }

        private void BTN_Navigate_Click(object sender, RoutedEventArgs e)
        {
            Page pageToNavigate;
            Button clickedButton = sender as Button;

            // Modifier profil
            if (clickedButton.Name == BTN_modifierProfil.Name) pageToNavigate = (accueilMonProfilPage = accueilMonProfilPage ?? new AccueilMonProfilPage());
            // Modifier Serveur BDD
            else if (clickedButton.Name == BTN_modifierServeurBDD.Name) pageToNavigate = (accueilBDDParametrePage = accueilBDDParametrePage ?? new AccueilBDDParametrePage());
            // Modifier Serveur Mail
            else if (clickedButton.Name == BTN_modifierServeurMail.Name) pageToNavigate = (accueilMailParametrePage = accueilMailParametrePage ?? new AccueilMailParametrePage());
            // Modifier Gestion Utilisateur
            else if (clickedButton.Name == BTN_gestionUtilisateurs.Name) pageToNavigate = (accueilUtilisateursPage = accueilUtilisateursPage ?? new AccueilUtilisateurPage());
            // Autres
            else throw new Exception("Impossible de naviguer vers une page depuis le bouton : [" + clickedButton.Name + "].") { };
            
            NavigationService.Navigate(pageToNavigate);
        }
    }
}
