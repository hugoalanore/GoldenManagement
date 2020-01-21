using GoldenManagement.Views;
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
using GoldenManagement.Views.Personne.Apprenant;
using GoldenManagement.Views.Personne.Formateur;
using GoldenManagement.Views.Formation;
using GoldenManagement.Views.Lieu;
using GoldenManagement.Views.Materiel;
using GoldenManagement.Views.Application.Parametre;
using GoldenManagement.Views.Planning;
using GoldenManagement.Views.Facturation;
using GoldenManagement.Views.Application.AppBar;

namespace GoldenManagement.Views.Application
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

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.StateChanged += new EventHandler(MainWindow_StateChanged);

            AccueilPage = new AccueilPage();
            MainFrame.Content = AccueilPage;
        }

        #region Gestion de la barre d'application
        private bool windowsIsMaximize = false;
        private double windowsNormalWidth = 0;
        private double windowsNormalHeight = 0;
        
        void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {
                if (windowsIsMaximize == false)
                {
                    windowsNormalWidth = this.Width;
                    windowsNormalHeight = this.Height;
                    this.Left = SystemParameters.WorkArea.Left;
                    this.Top = SystemParameters.WorkArea.Top;
                    this.Height = SystemParameters.WorkArea.Height;
                    this.Width = SystemParameters.WorkArea.Width;
                    BTN_maximiser_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
                    windowsIsMaximize = true;
                }
            }
        }

        private void BTN_maximiser_Click(object sender, RoutedEventArgs e)
        {
            if (windowsIsMaximize)
            {
                this.Width = windowsNormalWidth;
                this.Height = windowsNormalHeight;
                BTN_maximiser_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
                windowsIsMaximize = false;
            }
            else if (!windowsIsMaximize)
            {
                windowsNormalWidth = this.Width;
                windowsNormalHeight = this.Height;
                this.Left = SystemParameters.WorkArea.Left;
                this.Top = SystemParameters.WorkArea.Top;
                this.Height = SystemParameters.WorkArea.Height;
                this.Width = SystemParameters.WorkArea.Width;
                BTN_maximiser_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
                windowsIsMaximize = true;
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
        #endregion

        #region Les boutons de navigation
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
                AccueilApprenantsPage = new AccueilApprenantPage();
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
        #endregion
    }
}
