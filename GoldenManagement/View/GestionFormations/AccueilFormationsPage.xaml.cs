using GoldenManagement.Controller.GestionFormations;
using GoldenManagement.Model.BusinessObjects;
using GoldenManagement.View.Tools;
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

namespace GoldenManagement.View.GestionFormations
{
    /// <summary>
    /// Logique d'interaction pour AccueilFormationsPage.xaml
    /// </summary>
    public partial class AccueilFormationsPage : Page
    {
        private readonly FormationsController FormationsController = FormationsController.Instance;
        private List<Formation> listFormations = new List<Formation>();

        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        MainWindow MainWindow;
        //AjouterFormations AjouterFormationsPage;

        public AccueilFormationsPage(MainWindow MainWindow)
        {
            InitializeComponent();
            GetAllFormations();
            this.MainWindow = MainWindow;
            AllFormationsTypes.ItemsSource = FormationsController.GetAllFormationsTypes();

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
                return ((item as Formation).Intitule.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0 || (item as Formation).Libelle.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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

            MainWindow.MainFrame.Content = new FicheFormationPage(id, this.MainWindow, this);
        }

        private void BTN_FormationType_Click(object sender, RoutedEventArgs e)
        {

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

        private void BTN_addFormationType_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
