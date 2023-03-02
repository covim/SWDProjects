using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;



namespace Swd.Bsp.Binding.Model
{
    public class TemperatureConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool isDegree = System.Convert.ToBoolean(values[1]);
            double temperature = System.Convert.ToDouble(values[0]);

            if (!isDegree)
            {
                return temperature * (9.0D / 5.0D) + 32;
            }
            else
            {
                return temperature;
            }

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
