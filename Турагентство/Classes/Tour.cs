using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                string result = Price.ToString();
                result = result.Substring(0, result.Length - 5);

                bool check;
                if (result.Length > 3)
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
                    result = result.Insert(result.Length-index, ",");

                    index += 4;

                    if (result.IndexOf(',') < 4)
                    {
                        check = false;
                    }
                }

                return result + " РУБ";
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
    }
}