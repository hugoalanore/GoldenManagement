using GoldenManagement.Controller;
using GoldenManagement.Controller.GestionUtilisateurs;
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

namespace GoldenManagement.View.GestionUtilisateurs
{
    /// <summary>
    /// Logique d'interaction pour ModifierUtilisateurPage.xaml
    /// </summary>
    public partial class ModifierUtilisateurPage : Page
    {
        private readonly UtilisateursController UtilisateursController = UtilisateursController.Instance;
        private readonly int idUtilisateur;
        private readonly MainWindow MainWindow;
        private AccueilUtilisateursPage AccueilUtilisateursPage;
        public Utilisateur Utilisateur { get; set; }

        public ModifierUtilisateurPage(int id, MainWindow MainWindow, AccueilUtilisateursPage AccueilUtilisateursPage)
        {
            InitializeComponent();
            idUtilisateur = id;
            GetUtilisateur();
            this.MainWindow = MainWindow;
            this.AccueilUtilisateursPage = AccueilUtilisateursPage;

            foreach (String role in UtilisateursController.GetAllRoleUtilisateur())
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
            UtilisateursController.GetUtilisateurById(idUtilisateur).Role.ToString();
            formModif.DataContext = UtilisateursController.GetUtilisateurById(idUtilisateur);
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
                UtilisateursController.UpdateUtilisateur(TB_prenom.Text, TB_nom.Text, TB_nomUtilisateur.Text, new RoleUtilisateur() { Designation = (EEnum.ERoleUtilisateur)Enum.Parse(typeof(EEnum.ERoleUtilisateur), CB_role.Text) }, this.idUtilisateur);
            }
        }

        private void BTN_supprimerUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            UtilisateursController.DeleteUtilisateur(this.idUtilisateur);
        }

        private void BTN_reinitialiserMDP_Click(object sender, RoutedEventArgs e)
        {
            UtilisateursController.ResetPassWord(this.idUtilisateur);
        }

        private void BTN_retour_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilUtilisateursPage == null)
            {
                AccueilUtilisateursPage = new AccueilUtilisateursPage(this.MainWindow);
            }
            MainWindow.MainFrame.Content = AccueilUtilisateursPage;
        }
    }
}
