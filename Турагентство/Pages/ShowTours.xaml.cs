using System;
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

namespace Турагентство
{
    /// <summary>
    /// Логика взаимодействия для ShowTours.xaml
    /// </summary>
    public partial class ShowTours : Page
    {
        public ShowTours()
        {
            InitializeComponent();

            List<Type> typesList = new List<Type>();
            typesList.Add(new Type()
            {
                Id = 0,
                Name = "Все типы",
                Description = null
            });

            foreach (Type item in BaseClass.TE.Type)
            {
                typesList.Add(item);
            }

            CbType.ItemsSource = typesList;
            CbType.SelectedValuePath = "Id";
            CbType.DisplayMemberPath = "Name";
            CbType.SelectedIndex = 0;
            Lv.ItemsSource = BaseClass.TE.Tour.ToList();
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void TBoxFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void chBActual_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            List<Tour> toursList = new List<Tour>();

            if ((int)CbType.SelectedValue != 0)
            {
                List<TypeOfTour> typesList = BaseClass.TE.TypeOfTour.Where(x => x.TypeId == (int)CbType.SelectedValue).ToList();
                foreach (TypeOfTour item in typesList)
                {
                    toursList.Add(BaseClass.TE.Tour.FirstOrDefault(x => x.Id == item.TourId));
                }
            }
            else
            {
                toursList = BaseClass.TE.Tour.ToList();
            }

            if (TBoxFind.Text.Length > 0)
            {
                List<Tour> tempList = new List<Tour>();

                for (int i = 0; i < toursList.Count; i++)
                {
                    bool already = true;

                    if (toursList[i].Name.ToLower().Contains(TBoxFind.Text.ToLower()))
                    {
                        tempList.Add(toursList[i]);
                        already = false;
                    }

                    if (toursList[i].Description != null && toursList[i].Description.ToLower().Contains(TBoxFind.Text.ToLower()) && already)
                    {
                        tempList.Add(toursList[i]);
                    }
                }

                toursList = tempList;
            }

            if ((bool)chBActual.IsChecked)
            {
                toursList = toursList.Where(x => x.IsActual).ToList();
            }

            switch (CbSort.SelectedIndex)
            {
                case 1:
                    toursList.Sort((x, y) => x.Price.CompareTo(y.Price));
                    break;
                case 2:
                    toursList.Sort((x, y) => x.Price.CompareTo(y.Price));
                    toursList.Reverse();
                    break;
            }

            Lv.ItemsSource = toursList;

            decimal cost = 0;
            foreach (Tour item in toursList)
            {
                cost += item.Price;
            }
            tbCost.Text = Convert.ToInt32(cost).ToString() + " руб.";
        }
    }
}