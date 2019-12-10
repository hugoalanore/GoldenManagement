﻿using GoldenManagement.Controller.GestionFormations;
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
    /// Logique d'interaction pour AjouterFormationPage.xaml
    /// </summary>
    public partial class AjouterFormationPage : Page
    {
        private readonly FormationsController FormationsController = FormationsController.Instance;
        private MainWindow MainWindow;
        private FicheFormationTypePage FicheFormationTypePage;

        public AjouterFormationPage(MainWindow MainWindow, FicheFormationTypePage FicheFormationTypePage)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            this.FicheFormationTypePage = FicheFormationTypePage;

            foreach (var formationType in FormationsController.GetAllFormationsTypes())
            {
                CB_libelle.Items.Add(formationType.Libelle);
            }
            CB_libelle.SelectedItem = FicheFormationTypePage.formationType;
        }

        private void BTN_annuler_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = FicheFormationTypePage;
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
                if (FormationsController.AddFormations(intitule, Int32.Parse(nbJour), libelle))
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
