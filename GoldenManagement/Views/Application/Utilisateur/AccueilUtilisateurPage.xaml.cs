using DataAccessLayer.Models;
using GoldenManagement.Controllers;
using GoldenManagement.Views.Outils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace GoldenManagement.Views.Application.Utilisateur
{
    public partial class AccueilUtilisateurPage : Page
    {
        private readonly GoldenApp _GA = GoldenApp.Instance;
        // private List<DataAccessLayer.Models.Utilisateur> utilisateurs = new List<DataAccessLayer.Models.Utilisateur>();
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        private TrulyObservableCollection<DataAccessLayer.Models.Utilisateur> _Utilisateurs;
        public TrulyObservableCollection<DataAccessLayer.Models.Utilisateur> Utilisateurs {
            get { return _Utilisateurs; }
            private set { }
        }

        AjouterUtilisateurPage AjouterUtilisateurPage;
        readonly MainWindow MainWindow;

        public AccueilUtilisateurPage(MainWindow MainWindow)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;

            // DATA BINDING
            _Utilisateurs = new TrulyObservableCollection<DataAccessLayer.Models.Utilisateur>(_GA.DataAccess.GetAllUtilisateurs());
            DataContext = this;

            LV_Utilisateurs.ItemsSource = Utilisateurs;
            Utilisateurs.CollectionChanged += Utilisateurs_CollectionChanged;
        }

        private void Utilisateurs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (DataAccessLayer.Models.Utilisateur item in e.NewItems)
                    item.PropertyChanged += Utilisateur_PropertyChanged;

            if (e.OldItems != null)
                foreach (DataAccessLayer.Models.Utilisateur item in e.OldItems)
                    item.PropertyChanged -= Utilisateur_PropertyChanged;
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
    }
}
