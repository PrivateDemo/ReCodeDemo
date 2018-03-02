using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Component.Pagination
{
    public class CustomerConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int temp;
            int.TryParse(value.ToString(), out temp);
            if (temp < 1)
            {
                return 1;
            }
            else
            {
                return temp;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int temp;
            int.TryParse(value.ToString(), out temp);
            if (temp < 1)
            {
                return 1;
            }
            else
            {
                return temp;
            }
        }
    }
}
