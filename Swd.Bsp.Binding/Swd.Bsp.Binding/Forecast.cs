using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double TemperatureLow { get; set;}


    }
}
