using GoldenManagement.Views.Application.Parametre;
using GoldenManagement.Views.Facturation;
using GoldenManagement.Views.Formation;
using GoldenManagement.Views.Lieu;
using GoldenManagement.Views.Materiel;
using GoldenManagement.Views.Personne.Apprenant;
using GoldenManagement.Views.Personne.Formateur;
using GoldenManagement.Views.Planning;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GoldenManagement.Views.Application
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AccueilPage accueilPage = null;
        private AccueilApprenantPage accueilApprenantPage = null;
        private AccueilFormateurPage accueilFormateurPage = null;
        private AccueilFormationPage accueilFormationPage = null;
        private AccueilLieuPage accueilLieuPage = null;
        private AccueilMaterielPage accueilMaterielPage = null;
        private AccueilParametrePage accueilParametrePage = null;
        private AccueilPlanningPage accueilPlanningPage = null;
        private AccueilFacturationPage accueilFacturationPage = null;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.StateChanged += new EventHandler(MainWindow_StateChanged);
            accueilPage = new AccueilPage();
            MainFrame.NavigationService.Navigate(accueilPage);
        }

        #region Gestion de la barre d'application
        private bool windowsIsMaximize = false;
        private double windowsNormalWidth = 0;
        private double windowsNormalHeight = 0;
        private double windowsPositionTop = 0;
        private double windowsPositionLeft = 0;

        private void MaximizeWindow()
        {
            windowsNormalWidth = this.Width;
            windowsNormalHeight = this.Height;
            windowsPositionTop = this.Top;
            windowsPositionLeft = this.Left;
            this.Left = SystemParameters.WorkArea.Left;
            this.Top = SystemParameters.WorkArea.Top;
            this.Height = SystemParameters.WorkArea.Height;
            this.Width = SystemParameters.WorkArea.Width;
            BTN_maximiser_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
            windowsIsMaximize = true;
        }

        private void NormalizeWindow()
        {
            this.Width = windowsNormalWidth;
            this.Height = windowsNormalHeight;
            this.Top = windowsPositionTop;
            this.Left = windowsPositionLeft;
            BTN_maximiser_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
            windowsIsMaximize = false;
        }

        void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                if (windowsIsMaximize == false) { MaximizeWindow(); }
            }
        }

        private void BTN_maximiser_Click(object sender, RoutedEventArgs e)
        {
            if (windowsIsMaximize) { NormalizeWindow(); }
            else { MaximizeWindow(); }
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

            if (e.MouseDevice.LeftButton == MouseButtonState.Released &&
                !(this.Left == SystemParameters.WorkArea.Left &&
                this.Top == SystemParameters.WorkArea.Top &&
                this.Height == SystemParameters.WorkArea.Height &&
                this.Width == SystemParameters.WorkArea.Width))
            {
                if (windowsIsMaximize)
                {
                    windowsPositionTop = this.Top;
                    windowsPositionLeft = this.Left;
                    NormalizeWindow();
                }
            }
        }

        private void CZ_appBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (windowsIsMaximize) { NormalizeWindow(); }
            else { MaximizeWindow(); }
        }
        #endregion

        #region La navigation
        private void BTN_Navigate_Click(object sender, RoutedEventArgs e)
        {
            Page pageToNavigate;
            Button clickedButton = sender as Button;

            // Accueil
            if (clickedButton.Name == BTN_accueil.Name) pageToNavigate = (accueilPage = accueilPage ?? new AccueilPage());
            // Planning
            else if (clickedButton.Name == BTN_planning.Name) pageToNavigate = (accueilPlanningPage = accueilPlanningPage ?? new AccueilPlanningPage());
            // Formation
            else if (clickedButton.Name == BTN_formations.Name) pageToNavigate = (accueilFormationPage = accueilFormationPage ?? new AccueilFormationPage());
            // Formateur
            else if (clickedButton.Name == BTN_formateurs.Name) pageToNavigate = (accueilFormateurPage = accueilFormateurPage ?? new AccueilFormateurPage());
            // Apprenant
            else if (clickedButton.Name == BTN_apprenants.Name) pageToNavigate = (accueilApprenantPage = accueilApprenantPage ?? new AccueilApprenantPage());
            // Salle
            else if (clickedButton.Name == BTN_salles.Name) pageToNavigate = (accueilLieuPage = accueilLieuPage ?? new AccueilLieuPage());
            // Materiel
            else if (clickedButton.Name == BTN_materiels.Name) pageToNavigate = (accueilMaterielPage = accueilMaterielPage ?? new AccueilMaterielPage());
            // Facturation
            else if (clickedButton.Name == BTN_facturation.Name) pageToNavigate = (accueilFacturationPage = accueilFacturationPage ?? new AccueilFacturationPage());
            // Paramètre
            else if (clickedButton.Name == BTN_parametres.Name) pageToNavigate = (accueilParametrePage = accueilParametrePage ?? new AccueilParametrePage());
            // Autres
            else throw new Exception("Impossible de naviguer vers une page depuis le bouton : [" + clickedButton.Name + "].") { };

            MainFrame.NavigationService.Navigate(pageToNavigate);
            SetColorButtonMenu(clickedButton);
        }

        private void SetColorButtonMenu(Button clickedButton)
        {
            SolidColorBrush couleurDefault = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));
            SolidColorBrush couleurClique = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));

            BTN_accueil.Background = (clickedButton.Name == BTN_accueil.Name) ? couleurClique : couleurDefault;
            BTN_planning.Background = (clickedButton.Name == BTN_planning.Name) ? couleurClique : couleurDefault;
            BTN_formations.Background = (clickedButton.Name == BTN_formations.Name) ? couleurClique : couleurDefault;
            BTN_formateurs.Background = (clickedButton.Name == BTN_formateurs.Name) ? couleurClique : couleurDefault;
            BTN_apprenants.Background = (clickedButton.Name == BTN_apprenants.Name) ? couleurClique : couleurDefault;
            BTN_salles.Background = (clickedButton.Name == BTN_salles.Name) ? couleurClique : couleurDefault;
            BTN_materiels.Background = (clickedButton.Name == BTN_materiels.Name) ? couleurClique : couleurDefault;
            BTN_facturation.Background = (clickedButton.Name == BTN_facturation.Name) ? couleurClique : couleurDefault;
            BTN_parametres.Background = (clickedButton.Name == BTN_parametres.Name) ? couleurClique : couleurDefault;
        }
        #endregion

    }
}
