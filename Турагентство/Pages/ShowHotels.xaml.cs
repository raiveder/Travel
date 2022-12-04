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

namespace Турагентство
{
    /// <summary>
    /// Логика взаимодействия для ShowHotels.xaml
    /// </summary>
    public partial class ShowHotels : Page
    {
        public ShowHotels()
        {
            InitializeComponent();
            dg.ItemsSource = BaseClass.TE.Hotel.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            BaseClass.MainFrame.Navigate(new MainMenu());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}