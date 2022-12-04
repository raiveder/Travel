using System.Windows;

namespace Турагентство
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BaseClass.TE = new TravelEntities();
            BaseClass.MainFrame = frm;
            BaseClass.MainFrame.Navigate(new MainMenu());
        }
    }
}