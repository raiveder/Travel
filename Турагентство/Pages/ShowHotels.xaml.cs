using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Турагентство
{
    /// <summary>
    /// Логика взаимодействия для ShowHotels.xaml
    /// </summary>
    public partial class ShowHotels : Page
    {
        Pagination Pagin = new Pagination();
        List<Hotel> HotelList = new List<Hotel>();
        bool Start = true;

        public ShowHotels()
        {
            InitializeComponent();
            HotelList = BaseClass.TE.Hotel.ToList();
            dg.ItemsSource = HotelList;
            DataContext = Pagin;
            tboxPageCount.Text = "10";
        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)
            {
                case "first":
                    Pagin.CurrentPage = 1;
                    break;
                case "last":
                    Pagin.CurrentPage = HotelList.Count;
                    break;
                case "back":
                    Pagin.CurrentPage--;
                    break;
                case "next":
                    Pagin.CurrentPage++;
                    break;
                default:
                    Pagin.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }

            dg.ItemsSource = HotelList.Skip(Pagin.CurrentPage * Pagin.CountPage - Pagin.CountPage).Take(Pagin.CountPage).ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            BaseClass.MainFrame.Navigate(new MainMenu());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tboxPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Pagin.CountPage = Convert.ToInt32(tboxPageCount.Text);
            }
            catch
            {
                Pagin.CountPage = HotelList.Count;
            }

            Pagin.CountList = HotelList.Count;
            dg.ItemsSource = HotelList.Skip(0).Take(Pagin.CountPage).ToList();

            if (!Start)
            {
                Pagin.CurrentPage = 1;
            }

            Start = false;
        }

        private void tbCountOfTours_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            int count = 0;

            foreach (HotelOfTour item in BaseClass.TE.HotelOfTour.ToList())
            {

            }
        }
    }
}