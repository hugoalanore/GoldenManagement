﻿using System;
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

namespace GoldenManagement.Views.Formation
{
    /// <summary>
    /// Logique d'interaction pour FicheFormationHistoriquePage.xaml
    /// </summary>
    public partial class FicheFormationHistoriquePage : Page
    {
        public FicheFormationHistoriquePage()
        {
            InitializeComponent();
        }


        private void LvUsersColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            /*GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                lvUsers.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            lvUsers.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));*/
        }

        private void BTN_retour_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_show_sessionFormation_Click(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
