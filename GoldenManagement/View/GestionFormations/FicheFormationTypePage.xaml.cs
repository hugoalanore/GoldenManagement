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
    /// Logique d'interaction pour FicheFormationTypePage.xaml
    /// </summary>
    public partial class FicheFormationTypePage : Page
    {
        private readonly FormationsController FormationsController = FormationsController.Instance;
        private List<Formation> listFormations = new List<Formation>();

        private int id;
        private MainWindow MainWindow;
        private AccueilFormationsPage AccueilFormationsPage;
        private AjouterFormationPage AjouterFormationPage;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public string formationType;

        public FicheFormationTypePage(int id, string formationType, MainWindow MainWindow)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            this.id = id;
            GetAllFormations();
            this.formationType = formationType;
            TB_titleFormationType.Text = formationType;
        }
        private void GetAllFormations()
        {
            listFormations = FormationsController.GetAllFormationByFormationType(id);
            lvUsers.ItemsSource = listFormations;


            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            view.Filter = UserFilter;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Formation).Intitule.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
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

        private void BTN_show_utilisateur_Click(object sender, MouseButtonEventArgs e)
        {

        }
        

        private void BTN_retour_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilFormationsPage == null)
            {
                AccueilFormationsPage = new AccueilFormationsPage(this.MainWindow);
            }
            MainWindow.MainFrame.Content = AccueilFormationsPage;
        }

        private void BTN_addFormation_Click(object sender, RoutedEventArgs e)
        {
            if (AjouterFormationPage == null)
            {
                AjouterFormationPage = new AjouterFormationPage(this.MainWindow, this);
            }
            MainWindow.MainFrame.Content = AjouterFormationPage;
        }
    }
}
