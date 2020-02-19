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
    /// Logique d'interaction pour AjouterDomaineFormationPage.xaml
    /// </summary>
    public partial class AjouterDomaineFormationPage : Page
    {
        private readonly FormationController FormationsController = FormationController.Instance;
        private AccueilFormationPage AccueilFormationPage;

        public AjouterDomaineFormationPage(AccueilFormationPage AccueilFormationsPage)
        {
            InitializeComponent();
            this.AccueilFormationPage = AccueilFormationsPage;
        }

        private void BTN_annuler_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(AccueilFormationPage);
        }

        private void BTN_ajouterTypeFormation_Click(object sender, RoutedEventArgs e)
        {
            string typeFormation = TB_nomTypeFormation.Text;

            try
            {
                TB_message.Text = String.Empty;
                if (FormationsController.AddTypeFormations(typeFormation))
                {
                    TB_message.Text = "Ajout Effectuer";
                    TB_nomTypeFormation.Text = String.Empty;
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
