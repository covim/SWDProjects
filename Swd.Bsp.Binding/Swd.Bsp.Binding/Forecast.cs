using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Swd.Bsp.Binding
{
    public enum GeneralForecast
    {
        Sunny,
        Dry,
        Rainy,
        Snowy,
        Cloudy
    }

    public class Forecast
    {
        public GeneralForecast GeneralForecast { get; set; }
        public double TemperatureHigh { get; set; }
        public double TemperatureLow { get; set; }

        public Forecast()
        {
            Random random = new Random();
            TemperatureLow = (double)random.Next(-5, 10);
            TemperatureLow -= random.NextDouble();
            TemperatureHigh = (double)random.Next(11, 32);
            TemperatureHigh -= random.NextDouble();
        }
    }


}
