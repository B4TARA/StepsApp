using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TestApp.Models;

namespace TestApp.Converters
{
    public class RowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Brush))
            {
                return null;
            }

            var r = value as Users;
            if(r==null)
            {
                return null;
            }
            if (((double)r.MaxSteps / r.AvgSteps) * 100 - 100 >= 200 || ((double)r.AvgSteps / r.MinSteps) * 100 - 100 >= 200)
            {
                return Brushes.Aquamarine;
            }
            else return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
