using GoldenManagement.Calendrier;
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

namespace GoldenManagement.View.GestionPlanning
{
    /// <summary>
    /// Logique d'interaction pour AccueilPlanningPage.xaml
    /// </summary>
    public partial class AccueilPlanningPage : Page
    {
        public CalendrierUC Calendrier { get; set; } = new CalendrierUC();

        public AccueilPlanningPage()
        {
            InitializeComponent();
            DataContext = this;
        }

    }
}
