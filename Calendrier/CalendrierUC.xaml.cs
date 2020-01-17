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
    /// Logique d'interaction pour CalendrierUC.xaml
    /// </summary>
    public partial class CalendrierUC : UserControl, INotifyPropertyChanged
    {
        private string _MoisAnneeTexte;
        public String MoisAnneeTexte {
            get { return _MoisAnneeTexte; }
            set {
                _MoisAnneeTexte = value;
                OnPropertyChanged("MoisAnneeTexte");
            }
        }

        private JourUC[] _Jours = new JourUC[42];
        public JourUC[] Jours {
            get { return _Jours; }
            set {
                _Jours = value;
                OnPropertyChanged("Jours");
            }
        }

        public CalendrierUC()
        {
            InitializeComponent();
            InitializeProperties();
            DataContext = this;
            SetFromDate(DateTime.Now);
        }

        public DateTime CurrentMonth { get; set; }

        private void InitializeProperties()
        {
            for (int i = 0; i < Jours.Count(); i++)
            {
                Jours[i] = new JourUC();
            }
        }

        public void SetFromDate(DateTime date)
        {
            const string LUNDI = "Monday";
            const string MARDI = "Tuesday";
            const string MERCREDI = "Wednesday";
            const string JEUDI = "Thursday";
            const string VENDREDI = "Friday";
            const string SAMEDI = "Saturday";
            const string DIMANCHE = "Sunday";

            const int COL_LUNDI = 0;
            const int COL_MARDI = 1;
            const int COL_MERCREDI = 2;
            const int COL_JEUDI = 3;
            const int COL_VENDREDI = 4;
            const int COL_SAMEDI = 5;
            const int COL_DIMANCHE = 6;

            int startPosition = 0;

            // Définit le Mois / Année du calendrier
            MoisAnneeTexte = date.ToString("MMMM", CultureInfo.CreateSpecificCulture("fr")).Substring(0, 1).ToUpper() + date.ToString("MMMM", CultureInfo.CreateSpecificCulture("fr")).Substring(1) + " " + date.Year;

            // Définit le mois courrant
            CurrentMonth = new DateTime(date.Year, date.Month, 1);

            DateTime first = new DateTime(date.Year, date.Month, 1);
            switch (first.DayOfWeek.ToString())
            {
                case LUNDI: startPosition = COL_LUNDI; break;
                case MARDI: startPosition = COL_MARDI; break;
                case MERCREDI: startPosition = COL_MERCREDI; break;
                case JEUDI: startPosition = COL_JEUDI; break;
                case VENDREDI: startPosition = COL_VENDREDI; break;
                case SAMEDI: startPosition = COL_SAMEDI; break;
                case DIMANCHE: startPosition = COL_DIMANCHE; break;
                default: break;
            }

            for (int i = 0; i < Jours.Count(); i++)
            {
                DateTime currentDate = first.AddDays(-startPosition + i);
                Jours[i].DateTime = currentDate;
                // Si c'est le aujourd'hui
                Jours[i].Background = (currentDate.Date == DateTime.Now.Date) ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA98274")) : new SolidColorBrush(Colors.Transparent);

                // Si la date ne fait pas partit du mois (avant & après)
                Jours[i].Opacity = (i < startPosition || currentDate.Month != CurrentMonth.Month) ? 0.1 : 1;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }

        private void BTN_mois_suivant_Click(object sender, RoutedEventArgs e)
        {
            SetFromDate(new DateTime(CurrentMonth.Year, CurrentMonth.Month, 1).AddMonths(1));
        }

        private void BTN_mois_precedent_Click(object sender, RoutedEventArgs e)
        {
            SetFromDate(new DateTime(CurrentMonth.Year, CurrentMonth.Month, 1).AddMonths(-1));
        }

        private void BTN_mois_courrant_Click(object sender, RoutedEventArgs e)
        {
            SetFromDate(DateTime.Now);
        }
    }
}
