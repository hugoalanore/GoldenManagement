using GoldenManagement.Controllers;
using GoldenManagement.Views.Outils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;


namespace GoldenManagement.Views.Formation
{
    /// <summary>
    /// Logique d'interaction pour AccueilFormationsPage.xaml
    /// </summary>
    public partial class AccueilFormationPage : Page
    {
        private readonly FormationController FormationsController = FormationController.Instance;
        private List<DataAccessLayer.Models.Formation> listFormations = new List<DataAccessLayer.Models.Formation>();

        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        //AjouterFormations AjouterFormationsPage;

        AjouterDomaineFormationPage AjouterDomaineFormationPage;

        public AccueilFormationPage()
        {
            InitializeComponent();
            GetAllFormations();
            AllFormationsTypes.ItemsSource = FormationsController.GetAllDomaineFormation();

        }

        private void GetAllFormations()
        {
            listFormations = FormationsController.GetAllFormations();
            lvUsers.ItemsSource = listFormations;


            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as DataAccessLayer.Models.Formation).Intitule.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0 || (item as DataAccessLayer.Models.Formation).Intitule.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
            TB_mySearch.Text = "Recherche : " + txtFilter.Text;
        }

        private void BTN_ajouter_formation_Click(object sender, RoutedEventArgs e)
        {
            /*if (AjouterFormationsPage == null)
            {
                AjouterFormationsPage = new AjouterFormations(this.DashboardWindowPage, this);
            }
            DashboardWindowPage.MainFrame.Content = AjouterFormationsPage;*/
        }

        private void BTN_show_utilisateur_Click(object sender, MouseButtonEventArgs e)
        {
            ListViewItem lvi = sender as ListViewItem;
            dynamic yourdataObject = lvi.DataContext;
            int id = yourdataObject.Id;

            NavigationService.Navigate(new FicheFormationPage(id, this));
        }

        private void BTN_FormationType_Click(object sender, RoutedEventArgs e)
        {
            var idFormationType = ((Button)sender).Tag;
            var formationType = ((Button)sender).Content;

            NavigationService.Navigate(new FicheDomaineFormationPage((int)idFormationType, formationType.ToString()));
        }

        private void BTN_addFormationType_Click(object sender, RoutedEventArgs e)
        {
            if (AjouterDomaineFormationPage == null)
            {
                AjouterDomaineFormationPage = new AjouterDomaineFormationPage(this);
            }
            NavigationService.Navigate(AjouterDomaineFormationPage);
        }

        private void lvUsersColumnHeader_Click(object sender, RoutedEventArgs e)
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

        /*private void DisplayPopup(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = true;
        }*/
    }
}
