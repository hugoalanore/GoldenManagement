using GoldenManagement.View;
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

namespace GoldenManagement
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AccueilPage = new AccueilPage();
            MainFrame.Content = AccueilPage;
        }

        private bool isMaximise = false;

        AccueilPage AccueilPage = null;
        Accueil2Page Accueil2Page = null;

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
            if (Accueil2Page == null)
            {
                Accueil2Page = new Accueil2Page();
            }
            MainFrame.Content = Accueil2Page;
            BTN_planning.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
            BTN_dashboard.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));
        }

        private void BTN_dashboard_Click(object sender, RoutedEventArgs e)
        {
            if (AccueilPage == null)
            {
                AccueilPage = new AccueilPage();
            }
            MainFrame.Content = AccueilPage;
            BTN_dashboard.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
            BTN_planning.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a98274"));

        }


    }
}
