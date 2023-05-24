using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Drawing;

namespace WeatherConsole
{
    internal class Program
    {

        
        static async Task Main(string[] args)
        {
            // https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=59.93&lon=10.72&altitude=90
            // https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=59.93&lon=10.72&altitude=90

            string latitude = "59.93";
            string longitude = "10.72";
            string altitude = "90";

            string requestString = GetRequestString(latitude, longitude, altitude);
            Console.WriteLine(GetRequestString(latitude, longitude, altitude));

            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(requestString);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("PostmanRuntime", "7.32.2"));
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(requestString);
            string jsonString = await response.Content.ReadAsStringAsync();

            Root wetterdaten = JsonConvert.DeserializeObject<Root>(jsonString);

            Console.WriteLine("Wetterdaten um 12:00 für die nächsten Tage");
            foreach (var timeTag in GetAllDataAtHourOfDayForTheNext_n_Days(wetterdaten, 12, 5))
            {
                Console.WriteLine("Datum: " + timeTag.time.ToString());
                Console.WriteLine("Temp: " + timeTag.data.instant.details.air_temperature.ToString() + "°C");
                Console.WriteLine("Gef. Temp.: " + CalculatePerceivedTemperature(timeTag.data.instant.details.air_temperature,
                                                                timeTag.data.instant.details.wind_speed).ToString("N1") + "°C");
                Console.WriteLine(timeTag.data.next_6_hours.summary.symbol_code.ToString() + ".png");
                var picture = Resource1.ResourceManager.GetObject(timeTag.data.next_6_hours.summary.symbol_code);
                Console.WriteLine(picture.ToString());
                Console.WriteLine();
            }

            Console.WriteLine("Wetterdaten für den restlichen Tag");
            foreach (var timeTag in GetAllDataForRemainingDay(wetterdaten))
            {
                Console.WriteLine("Datum: " + timeTag.time.ToString());
                Console.WriteLine("Temp: " + timeTag.data.instant.details.air_temperature.ToString() + "°C");
                Console.WriteLine("Gef. Temp.: " + CalculatePerceivedTemperature(timeTag.data.instant.details.air_temperature,
                                                                timeTag.data.instant.details.wind_speed).ToString("N1") + "°C");
                Console.WriteLine(timeTag.data.next_1_hours.summary.symbol_code.ToString() + ".png");
                var picture = Resource1.ResourceManager.GetObject(timeTag.data.next_6_hours.summary.symbol_code);
                Console.WriteLine(picture.ToString());
                Console.WriteLine();
            }


        }


        public static string GetRequestString(string latitude, string longitude, string altitude = "0")
        {
            string baseUrl = "https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=";
            return $"{baseUrl}{latitude}&lon={longitude}"; // &altitude={altitude}";   
        }

        public static List<Timeseries> GetAllDataAtHourOfDay(Root wetterdaten, int hourOfDay)
        {
            List<Timeseries> data = new List<Timeseries>();
            data = wetterdaten.properties.timeseries.Where(x => x.time.Hour == hourOfDay).ToList();
            return data;
        }

        public static List<Timeseries> GetAllDataAtHourOfDayForTheNext_n_Days(Root wetterdaten, int hourOfDay, int n_Days)
        {
            List<Timeseries> data = new List<Timeseries>();
            data = wetterdaten.properties.timeseries.Where(x => x.time.Hour == hourOfDay && x.time.Date > DateTime.Now.Date).Take(n_Days).ToList();
            return data;
        }

        public static List<Timeseries> GetAllDataForRemainingDay(Root wetterdaten)
        {
            return wetterdaten.properties.timeseries.Where(x => x.time.Date == DateTime.Now.Date).ToList();
        }

        //From ChatGpt 24.05.2023
        public static double CalculatePerceivedTemperature(double temperature, double windSpeed)
        {
            double perceivedTemperature = 13.12 + 0.6215 * temperature - 11.37 * Math.Pow(windSpeed, 0.16)
                                          + 0.3965 * temperature * Math.Pow(windSpeed, 0.16);
            return perceivedTemperature;
        }




    }
}