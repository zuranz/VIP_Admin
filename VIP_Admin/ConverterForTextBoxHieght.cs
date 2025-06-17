using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VIP_Admin
{
    public class ConverterForTextBoxHieght : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double height)
            {
             
                if (height >= 600)
                {
                    if ((string)parameter == "BigTextBox")
                        return 120;
                    return 40;
                }
                else
                {
                    if ((string)parameter == "BigTextBox")
                        return 60;
                    return 20;
                }
            }
            return value;

        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

