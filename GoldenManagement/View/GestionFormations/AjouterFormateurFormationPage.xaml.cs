using GoldenManagement.Controller.GestionFormateurs;
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
    /// Logique d'interaction pour AjouterFormateurFormationPage.xaml
    /// </summary>
    public partial class AjouterFormateurFormationPage : Page
    {
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private readonly FormationsController FormationsController = FormationsController.Instance;
        private readonly FormateursController FormateursController = FormateursController.Instance;
        private MainWindow MainWindow;
        private FicheFormationPage FicheFormationPage;
        private List<Formateur> listFormateurs = new List<Formateur>();

        public AjouterFormateurFormationPage(MainWindow MainWindow, FicheFormationPage FicheFormationPage)
        {
            InitializeComponent();
            GetAllFormateurs();
            this.MainWindow = MainWindow;
            this.FicheFormationPage = FicheFormationPage;
        }
        private void GetAllFormateurs()
        {
            listFormateurs = FormateursController.GetAllFormateursFormations();
            lvUsers.ItemsSource = listFormateurs;


            /*CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            view.Filter = UserFilter;*/
        }

        private void BTN_ajouterFormateurFormation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_annuler_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_show_utilisateur_Click(object sender, MouseButtonEventArgs e)
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
    }
}
