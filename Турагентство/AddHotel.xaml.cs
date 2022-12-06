using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Турагентство
{
    /// <summary>
    /// Логика взаимодействия для AddHotel.xaml
    /// </summary>
    public partial class AddHotel : Window
    {
        Hotel HOTEL;
        bool FlagCreate;

        public AddHotel()
        {
            InitializeComponent();

            cbCountry.ItemsSource = BaseClass.TE.Country.ToList();
            cbCountry.SelectedValuePath = "Code";
            cbCountry.DisplayMemberPath = "Name";

            FlagCreate = true;
        }

        public AddHotel(Hotel hotel)
        {
            InitializeComponent();

            btnAdd.Content = "Изменить";
            tbHeader.Text = "ИЗМЕНЕНИЕ ОТЕЛЯ";

            cbCountry.ItemsSource = BaseClass.TE.Country.ToList();
            cbCountry.SelectedValuePath = "Code";
            cbCountry.DisplayMemberPath = "Name";

            HOTEL = hotel;
            FlagCreate = false;

            tboxName.Text = hotel.Name;
            tboxStars.Text = hotel.CountOfStars.ToString();
            cbCountry.SelectedValue = hotel.CountryCode;
            tboxDescription.Text = hotel.Description;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckData())
            {
                if (FlagCreate)
                {
                    HOTEL = new Hotel();
                }

                HOTEL.Name = tboxName.Text;
                HOTEL.CountOfStars = Convert.ToInt32(tboxStars.Text);
                HOTEL.CountryCode = cbCountry.SelectedValue.ToString();
                HOTEL.Description = tboxDescription.Text;

                if (FlagCreate)
                {
                    BaseClass.TE.Hotel.Add(HOTEL);
                }
                BaseClass.TE.SaveChanges();

                if (FlagCreate)
                {
                    MessageBox.Show("Отель успешно добавлен", "Отели", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Отель успешно изменён", "Отели", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                Close();
            }
        }

        private bool CheckData()
        {
            if (tboxName.Text.Length == 0)
            {
                MessageBox.Show("Поле \"Название\" не должно быть пустым", "Отели", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (!Regex.IsMatch(tboxStars.Text, @"^[0-5]$"))
            {
                MessageBox.Show("Количество звёзд может быть от 0 до 5!", "Отели", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (cbCountry.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите страну", "Отели", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (tboxDescription.Text.Length == 0)
            {
                MessageBox.Show("Поле \"Описание\" не должно быть пустым", "Отели", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }
    }
}