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