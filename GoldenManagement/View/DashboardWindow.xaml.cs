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
using System.Windows.Shapes;

namespace GoldenManagement.View
{
    /// <summary>
    /// Logique d'interaction pour DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        private bool isMaximise = false;

        public DashboardWindow()
        {
            InitializeComponent();
            MainFrame.Content = new AccueilPage();
        }

        private void BTN_maximiser_Click(object sender, RoutedEventArgs e)
        {
            if (!isMaximise)
            {
                isMaximise = true;
                this.WindowState = WindowState.Maximized;
            } else
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
    }
}
