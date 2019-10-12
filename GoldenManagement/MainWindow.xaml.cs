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
            OpenConnexionWindow();
            this.Close();
        }

        private void OpenConnexionWindow()
        {
            // Ouvre la fenêtre de connexion
            ConnexionWindow connexionWindow = new ConnexionWindow();
            connexionWindow.ShowDialog();
        }
    }
}
