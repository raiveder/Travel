using System.Windows.Media;

namespace Турагентство
{
    public partial class Tour
    {
        public string ActualTourShow
        {
            get
            {
                if (IsActual)
                {
                    return "Актуален";
                }
                else
                {
                    return "Не актуален";
                }
            }
        }

        public string PriceShow
        {
            get
            {
                if (Price > 999)
                {
                    return GetStringCost(Price.ToString()) + " РУБ";
                }
                else
                {
                    return (int)Price + " РУБ";
                }
            }
        }

        public SolidColorBrush ActualTourColor
        {
            get
            {
                if (IsActual)
                {
                    return Brushes.Green;
                }
                else
                {
                    return Brushes.Red;
                }
            }
        }

        public static string GetStringCost(string cost)
        {
            cost = cost.Substring(0, cost.Length - 5);

            bool check;
            if (cost.Length > 3)
            {
                check = true;
            }
            else
            {
                check = false;
            }

            int index = 3;
            while (check)
            {
                cost = cost.Insert(cost.Length - index, ",");

                index += 4;

                if (cost.IndexOf(',') < 4)
                {
                    check = false;
                }
            }

            return cost;
        }
    }
}