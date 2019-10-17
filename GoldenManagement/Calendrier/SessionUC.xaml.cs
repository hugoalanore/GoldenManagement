using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace GoldenManagement.Calendrier
{
    /// <summary>
    /// Logique d'interaction pour JourUI.xaml
    /// </summary>
    public partial class SessionUC : UserControl, INotifyPropertyChanged
    {
        private Brush _Couleur;
        public Brush Couleur {
            get { return _Couleur; }
            set {
                _Couleur = value;
                OnPropertyChanged("Couleur");
            }
        }

        private string _Intitule;
        public String Intitule {
            get { return _Intitule; }
            set {
                _Intitule = value;
                OnPropertyChanged("Intitule");
            }
        }

        public SessionUC()
        {
            InitializeComponent();
            InitializeProperties();
            DataContext = this;
        }

        private void InitializeProperties()
        {
            Couleur = new SolidColorBrush(Colors.Transparent);
            Intitule = String.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
    }
}
