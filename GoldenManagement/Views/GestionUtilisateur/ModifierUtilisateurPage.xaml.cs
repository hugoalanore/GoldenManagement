using GoldenManagement.Controllers;
using GoldenManagement.Controllers.GestionUtilisateur;
using DataAccessLayer.Models;
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

namespace GoldenManagement.Views.GestionUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour ModifierUtilisateurPage.xaml
    /// </summary>
    public partial class ModifierUtilisateurPage : Page
    {
        private readonly UtilisateurController UtilisateurController = UtilisateurController.Instance;
        private readonly int idUtilisateur;
        private readonly MainWindow MainWindow;
        private AccueilUtilisateurPage AccueilUtilisateursPage;
        public Utilisateur Utilisateur { get; set; }

        public ModifierUtilisateurPage(int id, MainWindow MainWindow, AccueilUtilisateurPage AccueilUtilisateursPage)
        {
            InitializeComponent();
            idUtilisateur = id;
            GetUtilisateur();
            this.MainWindow = MainWindow;
            this.AccueilUtilisateursPage = AccueilUtilisateursPage;

            foreach (String role in UtilisateurController.GetAllRoleUtilisateur())
            {
                CB_role.Items.Add(role);
            }

            // All Field Lock
            TB_prenom.IsEnabled = false;
            TB_nom.IsEnabled = false;
            TB_nomUtilisateur.IsEnabled = false;
            CB_role.IsEnabled = false;
        }

        private void GetUtilisateur()
        {
            UtilisateurController.GetUtilisateurById(idUtilisateur).Role.ToString();
            formModif.DataContext = UtilisateurController.GetUtilisateurById(idUtilisateur);
        }

        private void BTN_modifierUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            if (TB_prenom.IsEnabled == false)
            {
                TB_prenom.IsEnabled = true;
                TB_nom.IsEnabled = true;
                TB_nomUtilisateur.IsEnabled = true;
                CB_role.IsEnabled = true;
            }
            else
            {
                UtilisateurController.UpdateUtilisateur(TB_prenom.Text, TB_nom.Text, TB_nomUtilisateur.Text, new RoleUtilisateur() { Designation = (EEnum.ERoleUtilisateur)Enum.Parse(typeof(EEnum.ERoleUtilisateur), CB_role.Text) }, this.idUtilisateur);
            }
        }

        private void BTN_supprimerUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            UtilisateurController.DeleteUtilisateur(this.idUtilisateur);
        }

        private void BTN_reinitialiserMDP_Click(object sender, RoutedEventArgs e)
        {
            UtilisateurController.ResetPassWord(this.idUtilisateur);
        }

        private void BTN_retour_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilUtilisateursPage == null)
            {
                AccueilUtilisateursPage = new AccueilUtilisateurPage(this.MainWindow);
            }
            MainWindow.MainFrame.Content = AccueilUtilisateursPage;
        }
    }
}
