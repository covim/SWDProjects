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
    public class GeneralForecastToBrushConverter : IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Forecast fc = (Forecast)value;
            GeneralForecast gfc = (GeneralForecast)fc.GeneralForecast;
            switch (gfc)
            {
                case GeneralForecast.Sunny:
                    return Brushes.Yellow;
                    break;
                case GeneralForecast.Dry:
                    return Brushes.SandyBrown;
                    break;
                case GeneralForecast.Rainy:
                    return Brushes.LightBlue;
                    break;
                case GeneralForecast.Snowy:
                    return Brushes.White;
                    break;
                case GeneralForecast.Cloudy:
                    return Brushes.Gray;
                    break;
                default:                    
                    break;
            }

            return System.Windows.Data.Binding.DoNothing;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
