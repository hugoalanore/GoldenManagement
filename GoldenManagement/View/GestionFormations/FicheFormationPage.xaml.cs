using GoldenManagement.Controller.GestionFormations;
using GoldenManagement.Controller.GestionMateriels;
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
    /// Logique d'interaction pour FicheFormationPage.xaml
    /// </summary>
    public partial class FicheFormationPage : Page
    {
        private readonly FormationsController FormationsController = FormationsController.Instance;
        private readonly MaterielsController MaterielsController = MaterielsController.Instance;
        private int idFormation;
        private MainWindow MainWindow;
        private AccueilFormationsPage AccueilFormationsPage;

        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        public FicheFormationPage(int id, MainWindow MainWindow, AccueilFormationsPage AccueilFormationsPage)
        {
            InitializeComponent();
            this.idFormation = id;
            this.MainWindow = MainWindow;
            this.AccueilFormationsPage = AccueilFormationsPage;
            GetFormation();

            // ComboBox Formation
            CB_libelle.ItemsSource = FormationsController.GetAllFormationsTypes();

            // ComboBox Materiel
            CB_Materiel.ItemsSource = MaterielsController.GetAllMateriels();
            CB_Materiel.DisplayMemberPath = "Libelle";
        }

        public void GetMateriel()
        {
            lvUsers.ItemsSource = FormationsController.GetFormationById(this.idFormation).MaterielsFormation;
        }

        private void GetFormation()
        {
            Formation formation = FormationsController.GetFormationById(this.idFormation);
            formModif.DataContext = formation;
            lvUsers.ItemsSource = formation.MaterielsFormation;
        }

        private void BTN_modifierFormation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TB_message.Text = String.Empty;
                if (FormationsController.UpdateFormation(this.idFormation, CB_libelle.Text, Int32.Parse(TB_nbJour.Text), TB_intitule.Text))
                {
                    TB_message.Text = "Modif Effectuer";
                }
                else
                {
                    TB_message.Text = "Modif Erreur";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BTN_ajoutMateriel_Click(object sender, RoutedEventArgs e)
        {
            //TODO ajout by selection materiel & requete SQL
            if (CB_Materiel.Text != string.Empty && TB_Quatite.Text != string.Empty)
            {
                MaterielsController.addMaterielFormation(this.idFormation, CB_Materiel.Text, Convert.ToInt32(TB_Quatite.Text));
                GetMateriel();
                TB_message.Text = "Ajout Materiel Validé";
            }
            else if (CB_Materiel.Text == string.Empty)
            {
                TB_message.Text = "Error Materiel Non Choisie";
            }
            else if (TB_Quatite.Text == string.Empty)
            {
                TB_message.Text = "Error Quantite Non Definie";
            }
        }

        private void BTN_deleteMateriel_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem lvi = sender as ListViewItem;
            dynamic yourdataObject = lvi.DataContext;
            int id = yourdataObject.Id;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                MaterielsController.deleteMaterielFormation(id);
                GetMateriel();
            }
        }

        private void BTN_ajoutFormateur_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_deleteFormateur_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void BTN_supprimerFormation_Click(object sender, RoutedEventArgs e)
        {
            FormationsController.DeleteFormation(this.idFormation);
        }

        private void BTN_retour_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilFormationsPage == null)
            {
                AccueilFormationsPage = new AccueilFormationsPage(this.MainWindow);
            }
            MainWindow.MainFrame.Content = AccueilFormationsPage;
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

