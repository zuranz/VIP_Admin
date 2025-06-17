using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VIP_Admin
{
    public class ConverterForTextBox : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double wight)
            {
                if (wight >= 1000 && wight < 1200)
                    return wight - 400;
                else if (wight >= 1200)
                    return wight - 550;
                else
                    return wight-400;
            }
            return value;

        }

   
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
