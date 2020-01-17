﻿using GoldenManagement.Views;
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
using GoldenManagement.Views.GestionApprenant;
using GoldenManagement.Views.GestionFormateur;
using GoldenManagement.Views.GestionFormation;
using GoldenManagement.Views.GestionLieu;
using GoldenManagement.Views.GestionMateriel;
using GoldenManagement.Views.GestionParametre;
using GoldenManagement.Views.GestionPlanning;
using GoldenManagement.Views.GestionFacturation;

namespace GoldenManagement
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccueilPage AccueilPage = null;
        AccueilApprenantPage AccueilApprenantsPage = null;
        AccueilFormateurPage AccueilFormateursPage = null;
        AccueilFormationPage AccueilFormationsPage = null;
        AccueilLieuPage AccueilLieuxPage = null;
        AccueilMaterielPage AccueilMaterielsPage = null;
        AccueilParametrePage AccueilParametresPage = null;
        AccueilPlanningPage AccueilPlanningPage = null;
        AccueilFacturationPage AccueilFacturationPage = null;

        private bool isMaximise = false;

        public MainWindow()
        {
            InitializeComponent();
            AccueilPage = new AccueilPage();
            MainFrame.Content = AccueilPage;
        }
        
        private void BTN_maximiser_Click(object sender, RoutedEventArgs e)
        {
            if (!isMaximise)
            {
                isMaximise = true;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                isMaximise = false;
                this.WindowState = WindowState.Normal;
            }
        }

        private void BTN_fermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTN_minimiser_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CZ_appBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void BTN_planning_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilPlanningPage == null)
            {
                AccueilPlanningPage = new AccueilPlanningPage();
            }
            MainFrame.Content = AccueilPlanningPage;
            ResetColorButtonMenu();
            BTN_planning.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
        }

        private void BTN_accueil_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilPage == null)
            {
                AccueilPage = new AccueilPage();
            }
            MainFrame.Content = AccueilPage;
            ResetColorButtonMenu();
            BTN_accueil.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));

        }

        private void BTN_formations_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilFormationsPage == null)
            {
                AccueilFormationsPage = new AccueilFormationPage();
            }
            MainFrame.Content = AccueilFormationsPage;
            ResetColorButtonMenu();
            BTN_formations.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
        }

        private void BTN_formateurs_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilFormateursPage == null)
            {
                AccueilFormateursPage = new AccueilFormateurPage();
            }
            MainFrame.Content = AccueilFormateursPage;
            ResetColorButtonMenu();
            BTN_formateurs.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
        }

        private void BTN_apprenants_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilApprenantsPage == null)
            {
                AccueilApprenantsPage = new AccueilApprenantPage(this);
            }
            MainFrame.Content = AccueilApprenantsPage;
            ResetColorButtonMenu();
            BTN_apprenants.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
        }

        private void BTN_salles_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilLieuxPage == null)
            {
                AccueilLieuxPage = new AccueilLieuPage();
            }
            MainFrame.Content = AccueilLieuxPage;
            ResetColorButtonMenu();
            BTN_salles.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
        }

        private void BTN_materiels_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilMaterielsPage == null)
            {
                AccueilMaterielsPage = new AccueilMaterielPage();
            }
            MainFrame.Content = AccueilMaterielsPage;
            ResetColorButtonMenu();
            BTN_materiels.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
        }

        private void BTN_facturation_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilFacturationPage == null)
            {
                AccueilFacturationPage = new AccueilFacturationPage();
            }
            MainFrame.Content = AccueilFacturationPage;
            ResetColorButtonMenu();
            BTN_facturation.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
        }

        private void BTN_parametres_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilParametresPage == null)
            {
                AccueilParametresPage = new AccueilParametrePage(this);
            }
            MainFrame.Content = AccueilParametresPage;
            ResetColorButtonMenu();
            BTN_parametres.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
        }

        private void ResetColorButtonMenu()
        {
            BTN_accueil.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));
            BTN_planning.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));
            BTN_formations.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));
            BTN_formateurs.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));
            BTN_apprenants.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));
            BTN_salles.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));
            BTN_materiels.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));
            BTN_facturation.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));
            BTN_parametres.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));
        }
    }
}
