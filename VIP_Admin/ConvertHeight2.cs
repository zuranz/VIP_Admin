using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VIP_Admin
{
    public class ConvertHeight2 : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double height)
            {
                if (height >= 500)
                {
                    return height - 100;
                }
                else
                {
                    return height;
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
//"server=localhost;userid=root;password=crash;database=VIPClubs;characterset=utf8mb4"