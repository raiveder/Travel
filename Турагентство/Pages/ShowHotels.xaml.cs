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
            AddHotel addHotel = new AddHotel();
            addHotel.ShowDialog();
            HotelList = BaseClass.TE.Hotel.ToList();
            SetPagination();
        }

        private void tboxPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetPagination();
        }

        private void SetPagination()
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

            int id = Convert.ToInt32(tb.Uid);

            tb.Text = BaseClass.TE.HotelOfTour.Where(x => x.HotelId == id).ToList().Count.ToString();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            int id = Convert.ToInt32(btn.Uid);

            if (!IsActualHotel(id))
            {
                Hotel hotel = BaseClass.TE.Hotel.FirstOrDefault(x => x.Id == id);
                MessageBoxResult response = MessageBox.Show("Вы действительно хотите удалить отель \"" + hotel.Name + "\"?", "Отели", MessageBoxButton.YesNo, MessageBoxImage.Information);
                SetPagination();
                if (response == MessageBoxResult.Yes)
                {
                    BaseClass.TE.Hotel.Remove(hotel);
                    BaseClass.TE.SaveChanges();
                    HotelList = BaseClass.TE.Hotel.ToList();
                }
            }
            else
            {
                MessageBox.Show("Отель подходит для актуальных туров!", "Отели", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool IsActualHotel(int id)
        {
            foreach (HotelOfTour item in BaseClass.TE.HotelOfTour.Where(x => x.HotelId == id).ToList())
            {
                if (item.Tour.IsActual)
                {
                    return true;
                }
            }

            return false;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            int id = Convert.ToInt32(btn.Uid);

            Hotel hotel = BaseClass.TE.Hotel.FirstOrDefault(x => x.Id == id);

            AddHotel addHotel = new AddHotel(hotel);
            addHotel.ShowDialog();
            SetPagination();
        }
    }
}