using GoldenManagement.Controller.GestionFormations;
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

namespace GoldenManagement.View.GestionFormations
{
    /// <summary>
    /// Logique d'interaction pour AjouterFormationTypePage.xaml
    /// </summary>
    public partial class AjouterFormationTypePage : Page
    {
        private readonly FormationsController FormationsController = FormationsController.Instance;
        private MainWindow MainWindow;
        private AccueilFormationsPage AccueilFormationsPage;

        public AjouterFormationTypePage(MainWindow MainWindow, AccueilFormationsPage AccueilFormationsPage)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            this.AccueilFormationsPage = AccueilFormationsPage;
        }

        private void BTN_annuler_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = AccueilFormationsPage;
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
