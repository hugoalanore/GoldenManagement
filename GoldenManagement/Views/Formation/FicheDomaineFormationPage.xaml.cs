using GoldenManagement.Controllers;
using GoldenManagement.Views.Outils;
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

namespace GoldenManagement.Views.Formation
{
    /// <summary>
    /// Logique d'interaction pour FicheDomaineFormationPage.xaml
    /// </summary>
    public partial class FicheDomaineFormationPage : Page
    {
        private readonly FormationController FormationsController = FormationController.Instance;
        private List<DataAccessLayer.Models.Formation> listFormations = new List<DataAccessLayer.Models.Formation>();

        private int id;
        private AccueilFormationPage AccueilFormationsPage;
        private AjouterFormationPage AjouterFormationPage;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public string formationType;

        public FicheDomaineFormationPage(int id, string formationType)
        {
            InitializeComponent();
            this.id = id;
            GetAllFormations();
            this.formationType = formationType;
            TB_titleFormationType.Text = formationType;
        }
        private void GetAllFormations()
        {
            // listFormations = FormationController.GetAllFormationByFormationType(id); // TODO mise a jour
            lvUsers.ItemsSource = listFormations;


            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            view.Filter = UserFilter;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as DataAccessLayer.Models.Formation).Intitule.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void TxtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
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
            ListViewItem lvi = sender as ListViewItem;
            dynamic yourdataObject = lvi.DataContext;
            int id = yourdataObject.Id;

            NavigationService.Navigate(new FicheFormationPage(id, this));
        }

        private void BTN_retour_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilFormationsPage == null)
            {
                AccueilFormationsPage = new AccueilFormationPage();
            }
            NavigationService.Navigate(AccueilFormationsPage);
        }

        private void BTN_addFormation_Click(object sender, RoutedEventArgs e)
        {
            if (AjouterFormationPage == null)
            {
                AjouterFormationPage = new AjouterFormationPage(this);
            }
            NavigationService.Navigate(AjouterFormationPage);
        }

        private void BTN_deleteFormation_Click(object sender, RoutedEventArgs e)
        {
            //TODO demander si delete des formation lier ou est active ?
        }
    }
}
