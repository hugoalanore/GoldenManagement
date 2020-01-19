using GoldenManagement.Controllers;
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
using DataAccessLayer.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GoldenManagement.Views.Application.Utilisateur
{
    /// <summary>
    /// Logique d'interaction pour ModifierUtilisateurPage.xaml
    /// </summary>
    public partial class ModifierUtilisateurPage : Page, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
        #endregion

        private readonly GoldenApp _GA = GoldenApp.Instance;

        private readonly MainWindow MainWindow;
        private AccueilUtilisateurPage AccueilUtilisateursPage;

        private DataAccessLayer.Models.Utilisateur _Utilisateur;
        public DataAccessLayer.Models.Utilisateur Utilisateur {
            get { return _Utilisateur; }
            set { if (_Utilisateur != value) { _Utilisateur = value; NotifyPropertyChanged(); } }
        }

        public ModifierUtilisateurPage(int id, MainWindow MainWindow, AccueilUtilisateurPage AccueilUtilisateursPage)
        {
            InitializeComponent();
            Utilisateur = _GA.GetUtilisateurById(id);
            this.MainWindow = MainWindow;
            this.AccueilUtilisateursPage = AccueilUtilisateursPage;

            // All Field Lock
            TB_prenom.IsEnabled = false;
            TB_nom.IsEnabled = false;
            CB_role.IsEnabled = false;
        }

        private void BTN_modifierUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            if (TB_prenom.IsEnabled == false)
            {
                TB_prenom.IsEnabled = true;
                TB_nom.IsEnabled = true;
                CB_role.IsEnabled = true;
            }
            else
            {
                // _GA.UpdateUtilisateur(TB_prenom.Text, TB_nom.Text, new RoleUtilisateur() { DesignationString = CB_role.Text }, this.idUtilisateur);
                _GA.UpdateUtilisateur(Utilisateur.Prenom, Utilisateur.Nom, new RoleUtilisateur() { Designation = (ERoleUtilisateur)CB_role.SelectedItem }, Utilisateur.Id);
            }
        }

        private void BTN_supprimerUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            _GA.DeleteUtilisateur(Utilisateur.Id);
        }

        private void BTN_reinitialiserMDP_Click(object sender, RoutedEventArgs e)
        {
            _GA.ResetPassWord(Utilisateur.Id);
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
