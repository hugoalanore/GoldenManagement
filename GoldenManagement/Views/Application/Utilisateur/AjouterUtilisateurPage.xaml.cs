using DataAccessLayer.Models;
using GoldenManagement.Controllers;
using System;
using DataAccessLayer.Enums;
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
using System.Collections.ObjectModel;

namespace GoldenManagement.Views.Application.Utilisateur
{
    /// <summary>
    /// Logique d'interaction pour AjouterUtilisateurPage.xaml
    /// </summary>
    public partial class AjouterUtilisateurPage : Page
    {

        private readonly GoldenApp _GA = GoldenApp.Instance;
        private readonly MainWindow MainWindow;
        private AccueilUtilisateurPage AccueilUtilisateursPage;

        public AjouterUtilisateurPage(MainWindow MainWindow, AccueilUtilisateurPage AccueilUtilisateursPage)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            this.AccueilUtilisateursPage = AccueilUtilisateursPage;

            foreach (ERoleUtilisateur roleUtilisateur in (ERoleUtilisateur[])Enum.GetValues(typeof(ERoleUtilisateur)))
            {
                CB_role.Items.Add(roleUtilisateur);
            }
        }

        private void BTN_retour_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilUtilisateursPage == null)
            {
                AccueilUtilisateursPage = new AccueilUtilisateurPage(this.MainWindow);
            }
            MainWindow.MainFrame.Content = AccueilUtilisateursPage;
        }

        private void BTN_ajouterUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            string prenom = TB_prenom.Text;
            string nom = TB_nom.Text;
            string nomUtilisateur = TB_nomUtilisateur.Text;
            string role = CB_role.Text;
            string motDePasse = PB_motDePasse.Password;
            string motDePasseConfirmation = PB_motDePasseConfirmation.Password;

            try
            {
                if (motDePasse != motDePasseConfirmation)
                {
                    TB_message.Text = "Mot de passe incorrect";
                    PB_motDePasse.Password = String.Empty;
                    PB_motDePasseConfirmation.Password = String.Empty;
                }
                else
                {
                    TB_message.Text = String.Empty;
                    if (_GA.AddUtilisateur(prenom, nom, nomUtilisateur, motDePasse, new RoleUtilisateur() { DesignationString =  role }))
                    {
                        TB_message.Text = "Ajout éffectué";
                        TB_prenom.Text = String.Empty;
                        TB_nom.Text = String.Empty;
                        TB_nomUtilisateur.Text = String.Empty;
                        CB_role.Text = String.Empty;
                        PB_motDePasse.Password = String.Empty;
                        PB_motDePasseConfirmation.Password = String.Empty;
                        AccueilUtilisateursPage.lesUtilisateurs = new ObservableCollection<DataAccessLayer.Models.Utilisateur>(_GA.GetAllUtilsateurs());
                    }
                    else
                    {
                        TB_message.Text = "Erreur dans l'ajout";
                        PB_motDePasseConfirmation.Password = String.Empty;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
