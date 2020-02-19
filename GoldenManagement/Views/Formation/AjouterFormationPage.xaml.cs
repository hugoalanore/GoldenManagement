using DataAccessLayer.Models;
using GoldenManagement.Controllers;
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

namespace GoldenManagement.Views.Formation
{
    /// <summary>
    /// Logique d'interaction pour AjouterFormationPage.xaml
    /// </summary>
    public partial class AjouterFormationPage : Page
    {
        private readonly FormationController FormationsController = FormationController.Instance;
        private FicheDomaineFormationPage FicheDomaineFormationPage;

        public AjouterFormationPage(FicheDomaineFormationPage FicheDomaineFormationPage)
        {
            InitializeComponent();
            this.FicheDomaineFormationPage = FicheDomaineFormationPage;

            foreach (var formationType in FormationsController.GetAllDomaineFormation())
            {
                CB_libelle.Items.Add(formationType.Designation);
            }
            CB_libelle.SelectedItem = FicheDomaineFormationPage.formationType;
        }

        private void BTN_annuler_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(FicheDomaineFormationPage);
        }

        private void BTN_ajoutMateriel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_ajouterFormation_Click(object sender, RoutedEventArgs e)
        {
            string intitule = TB_intitule.Text;
            string nbJour = TB_nbJour.Text;
            string libelle = CB_libelle.Text;
            
            try
            {
                TB_message.Text = String.Empty;
                if (FormationsController.AddFormations(intitule, Int32.Parse(nbJour), FormationController.Instance.GetDomaineFormationByDesignation(libelle)))
                {
                    TB_message.Text = "Ajout Effectuer";
                    TB_intitule.Text = String.Empty;
                    TB_nbJour.Text = String.Empty;
                    CB_libelle.Text = String.Empty;
                }
                else
                {
                    TB_message.Text = "Ajout erreur";
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
