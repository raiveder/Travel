using System.Windows;
using System.Windows.Controls;

namespace Турагентство
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnTours_Click(object sender, RoutedEventArgs e)
        {
            BaseClass.MainFrame.Navigate(new ShowTours());
        }

        private void btnHotels_Click(object sender, RoutedEventArgs e)
        {
            BaseClass.MainFrame.Navigate(new ShowHotels());
        }
    }
}