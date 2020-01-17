using DataAccessLayer.Models;
using GoldenManagement.Controllers;
using GoldenManagement.Controllers.GestionUtilisateur;
using GoldenManagement.Views.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class AccueilUtilisateurPage : Page
    {

        private readonly UtilisateurController UtilisateursController = UtilisateurController.Instance;
        private List<Utilisateur> listUtilisateurs = new List<Utilisateur>();
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        AjouterUtilisateurPage AjouterUtilisateurPage;
        readonly MainWindow MainWindow;

        public AccueilUtilisateurPage(MainWindow MainWindow)
        {
            InitializeComponent();
            GetAllUtilisateurs();
            this.MainWindow = MainWindow;
        }

        private void GetAllUtilisateurs()
        {
            listUtilisateurs = UtilisateursController.GetAllUtilsateurs();
            lvUsers.ItemsSource = listUtilisateurs;
        }

        private void BTN_ajouter_utilisateur_Click(object sender, RoutedEventArgs e)
        {
            if (AjouterUtilisateurPage == null)
            {
                AjouterUtilisateurPage = new AjouterUtilisateurPage(this.MainWindow, this);
            }
            MainWindow.MainFrame.Content = AjouterUtilisateurPage;
        }

        private void BTN_show_utilisateur_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem lvi = sender as ListViewItem;
            dynamic yourdataObject = lvi.DataContext;
            int id = yourdataObject.Id;

            MainWindow.MainFrame.Content = new ModifierUtilisateurPage(id, this.MainWindow, this);
        }

        private void LvUsersColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                lvUsers.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            lvUsers.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        private void BTN_show_utilisateur_Click(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
