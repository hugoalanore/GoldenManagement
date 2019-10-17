using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    public partial class JourUC : UserControl, INotifyPropertyChanged
    {
        private SessionUC[] _Sessions = new SessionUC[7];
        public SessionUC[] Sessions {
            get { return _Sessions; }
            set {
                _Sessions = value;
                OnPropertyChanged("Sessions");
            }
        }

        private string _Date;
        public String Date {
            get { return _Date; }
            set {
                _Date = value;
                OnPropertyChanged("Date");
            }
        }

        private DateTime _DateTime;
        public DateTime DateTime {
            get { return DateTime; }
            set {
                _DateTime = value;
                if (value.Day == 1) { Date = "1 " + value.ToString("MMM", CultureInfo.CreateSpecificCulture("fr")).Substring(0, 1).ToUpper() + value.ToString("MMM", CultureInfo.CreateSpecificCulture("fr")).Substring(1); }
                else { Date = value.Day.ToString(); }
            }
        }

        public JourUC()
        {
            InitializeComponent();
            InitializeProperties();
            DataContext = this;
        }

        public void InitializeProperties()
        {
            for (int i = 0; i < Sessions.Count(); i++)
            {
                Sessions[i] = new SessionUC();
                Sessions[i].Visibility = Visibility.Hidden;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
    }
}
