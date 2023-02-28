using Swd.Bsp.Binding.Model;
using Swd.Bsp.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Swd.Bsp.Binding.View
{

    /// <summary>
    /// Interaction logic for fTemplates.xaml
    /// </summary>
    public partial class fForecast : Window
    {

        private Window _callerWindow;
        private ObservableCollection<Customer> _customerList;

        string resultString;




        public ObservableCollection<Customer> CustomerList
        {
            get { return _customerList; }
            set { _customerList = value; }
        }


        public Window CallerWindow
        {
            get { return _callerWindow; }
            set { _callerWindow = value; }
        }

        public fForecast()
        {
            InitializeComponent();
            this.DataContext = new fForecastViewModel();
        }

        public fForecast(Window callerWindow) : this()
        {
            CallerWindow = callerWindow;

        }
             
               

        private void GetForecast()
        {
            string returnValue = "{\r\n \"queryCost\": 1,\r\n \"latitude\": 47.4263,\r\n \"longitude\": 9.65865,\r\n \"resolvedAddress\": \"Lustenau, Vorarlberg, Österreich\",\r\n \"address\": \"Lustenau\",\r\n \"timezone\": \"Europe/Vienna\",\r\n \"tzoffset\": 1,\r\n \"description\": \"Similar temperatures continuing with a chance of rain Tuesday.\",\r\n \"days\": [\r\n  {\r\n   \"datetime\": \"2023-02-28\",\r\n   \"datetimeEpoch\": 1677538800,\r\n   \"tempmax\": 3,\r\n   \"tempmin\": -3,\r\n   \"temp\": -0.5,\r\n   \"feelslikemax\": 1,\r\n   \"feelslikemin\": -5.2,\r\n   \"feelslike\": -2.1,\r\n   \"dew\": -3.2,\r\n   \"humidity\": 82.6,\r\n   \"precip\": 0,\r\n   \"precipprob\": 0,\r\n   \"precipcover\": 0,\r\n   \"preciptype\": null,\r\n   \"snow\": 0,\r\n   \"snowdepth\": 3.7,\r\n   \"windgust\": 23.4,\r\n   \"windspeed\": 16.6,\r\n   \"winddir\": 6.6,\r\n   \"pressure\": 1021.8,\r\n   \"cloudcover\": 68.3,\r\n   \"visibility\": 12.9,\r\n   \"solarradiation\": 35.3,\r\n   \"solarenergy\": 3,\r\n   \"uvindex\": 1,\r\n   \"severerisk\": 10,\r\n   \"sunrise\": \"07:04:22\",\r\n   \"sunriseEpoch\": 1677564262,\r\n   \"sunset\": \"18:04:20\",\r\n   \"sunsetEpoch\": 1677603860,\r\n   \"moonphase\": 0.27,\r\n   \"conditions\": \"Partially cloudy\",\r\n   \"description\": \"Partly cloudy throughout the day.\",\r\n   \"icon\": \"partly-cloudy-day\",\r\n   \"stations\": [\r\n    \"LSZR\",\r\n    \"AT546\"\r\n   ],\r\n   \"source\": \"comb\",\r\n   \"hours\": [\r\n    {\r\n     \"datetime\": \"12:00:00\",\r\n     \"datetimeEpoch\": 1677582000,\r\n     \"temp\": 0,\r\n     \"feelslike\": -3.2,\r\n     \"humidity\": 69.05,\r\n     \"dew\": -5,\r\n     \"precip\": 0,\r\n     \"precipprob\": 0,\r\n     \"snow\": 0,\r\n     \"snowdepth\": 3.9,\r\n     \"preciptype\": null,\r\n     \"windgust\": 22.3,\r\n     \"windspeed\": 9.4,\r\n     \"winddir\": 350,\r\n     \"pressure\": 1022,\r\n     \"visibility\": 10,\r\n     \"cloudcover\": 50,\r\n     \"solarradiation\": 140,\r\n     \"solarenergy\": 0.5,\r\n     \"uvindex\": 1,\r\n     \"severerisk\": 10,\r\n     \"conditions\": \"Partially cloudy\",\r\n     \"icon\": \"partly-cloudy-day\",\r\n     \"stations\": [\r\n      \"LSZR\",\r\n      \"AT546\"\r\n     ],\r\n     \"source\": \"obs\"\r\n    },\r\n    {\r\n     \"datetime\": \"13:00:00\",\r\n     \"datetimeEpoch\": 1677585600,\r\n     \"temp\": 1,\r\n     \"feelslike\": 1,\r\n     \"humidity\": 69.26,\r\n     \"dew\": -4,\r\n     \"precip\": 0,\r\n     \"precipprob\": 0,\r\n     \"snow\": 0,\r\n     \"snowdepth\": 3.7,\r\n     \"preciptype\": null,\r\n     \"windgust\": 23.4,\r\n     \"windspeed\": 7.9,\r\n     \"winddir\": 0.2,\r\n     \"pressure\": 1022,\r\n     \"visibility\": 10,\r\n     \"cloudcover\": 50,\r\n     \"solarradiation\": 115,\r\n     \"solarenergy\": 0.4,\r\n     \"uvindex\": 1,\r\n     \"severerisk\": 10,\r\n     \"conditions\": \"Partially cloudy\",\r\n     \"icon\": \"partly-cloudy-day\",\r\n     \"stations\": [\r\n      \"LSZR\",\r\n      \"AT546\"\r\n     ],\r\n     \"source\": \"obs\"\r\n    }\r\n   ]\r\n  }\r\n ],\r\n \"alerts\": [],\r\n \"stations\": {\r\n  \"EDNY\": {\r\n   \"distance\": 29060,\r\n   \"latitude\": 47.67,\r\n   \"longitude\": 9.52,\r\n   \"useCount\": 0,\r\n   \"id\": \"EDNY\",\r\n   \"name\": \"EDNY\",\r\n   \"quality\": 50,\r\n   \"contribution\": 0\r\n  },\r\n  \"LSZR\": {\r\n   \"distance\": 10130,\r\n   \"latitude\": 47.48,\r\n   \"longitude\": 9.55,\r\n   \"useCount\": 0,\r\n   \"id\": \"LSZR\",\r\n   \"name\": \"LSZR\",\r\n   \"quality\": 50,\r\n   \"contribution\": 0\r\n  },\r\n  \"AT546\": {\r\n   \"distance\": 46923,\r\n   \"latitude\": 47.652,\r\n   \"longitude\": 9.132,\r\n   \"useCount\": 0,\r\n   \"id\": \"AT546\",\r\n   \"name\": \"HB9KNR Tagerwilen CH\",\r\n   \"quality\": 0,\r\n   \"contribution\": 0\r\n  },\r\n  \"EDJA\": {\r\n   \"distance\": 75041,\r\n   \"latitude\": 47.98,\r\n   \"longitude\": 10.23,\r\n   \"useCount\": 0,\r\n   \"id\": \"EDJA\",\r\n   \"name\": \"EDJA\",\r\n   \"quality\": 50,\r\n   \"contribution\": 0\r\n  }\r\n },\r\n \"currentConditions\": {\r\n  \"datetime\": \"18:50:00\",\r\n  \"datetimeEpoch\": 1677606600,\r\n  \"temp\": 0.7,\r\n  \"feelslike\": 0.7,\r\n  \"humidity\": 74.7,\r\n  \"dew\": -3.3,\r\n  \"precip\": 0,\r\n  \"precipprob\": 0,\r\n  \"snow\": 0,\r\n  \"snowdepth\": 0,\r\n  \"preciptype\": null,\r\n  \"windgust\": null,\r\n  \"windspeed\": 1.8,\r\n  \"winddir\": 338.8,\r\n  \"pressure\": 1023,\r\n  \"visibility\": 10,\r\n  \"cloudcover\": 88,\r\n  \"solarradiation\": 0,\r\n  \"solarenergy\": null,\r\n  \"uvindex\": 0,\r\n  \"conditions\": \"Partially cloudy\",\r\n  \"icon\": \"partly-cloudy-night\",\r\n  \"stations\": [\r\n   \"EDJA\",\r\n   \"EDNY\",\r\n   \"LSZR\"\r\n  ],\r\n  \"source\": \"obs\",\r\n  \"sunrise\": \"07:04:22\",\r\n  \"sunriseEpoch\": 1677564262,\r\n  \"sunset\": \"18:04:20\",\r\n  \"sunsetEpoch\": 1677603860,\r\n  \"moonphase\": 0.27\r\n }\r\n}";

        }

        private void btnLoadRealtimeData_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            var forecast = Temperatures.FromJson(resultString);

            //string returnValue = "{\r\n \"queryCost\": 1,\r\n \"latitude\": 47.4263,\r\n \"longitude\": 9.65865,\r\n \"resolvedAddress\": \"Lustenau, Vorarlberg, Österreich\",\r\n \"address\": \"Lustenau\",\r\n \"timezone\": \"Europe/Vienna\",\r\n \"tzoffset\": 1,\r\n \"description\": \"Similar temperatures continuing with a chance of rain Tuesday.\",\r\n \"days\": [\r\n  {\r\n   \"datetime\": \"2023-02-28\",\r\n   \"datetimeEpoch\": 1677538800,\r\n   \"tempmax\": 3,\r\n   \"tempmin\": -3,\r\n   \"temp\": -0.5,\r\n   \"feelslikemax\": 1,\r\n   \"feelslikemin\": -5.2,\r\n   \"feelslike\": -2.1,\r\n   \"dew\": -3.2,\r\n   \"humidity\": 82.6,\r\n   \"precip\": 0,\r\n   \"precipprob\": 0,\r\n   \"precipcover\": 0,\r\n   \"preciptype\": null,\r\n   \"snow\": 0,\r\n   \"snowdepth\": 3.7,\r\n   \"windgust\": 23.4,\r\n   \"windspeed\": 16.6,\r\n   \"winddir\": 6.6,\r\n   \"pressure\": 1021.8,\r\n   \"cloudcover\": 68.3,\r\n   \"visibility\": 12.9,\r\n   \"solarradiation\": 35.3,\r\n   \"solarenergy\": 3,\r\n   \"uvindex\": 1,\r\n   \"severerisk\": 10,\r\n   \"sunrise\": \"07:04:22\",\r\n   \"sunriseEpoch\": 1677564262,\r\n   \"sunset\": \"18:04:20\",\r\n   \"sunsetEpoch\": 1677603860,\r\n   \"moonphase\": 0.27,\r\n   \"conditions\": \"Partially cloudy\",\r\n   \"description\": \"Partly cloudy throughout the day.\",\r\n   \"icon\": \"partly-cloudy-day\",\r\n   \"stations\": [\r\n    \"LSZR\",\r\n    \"AT546\"\r\n   ],\r\n   \"source\": \"comb\",\r\n   \"hours\": [\r\n    {\r\n     \"datetime\": \"12:00:00\",\r\n     \"datetimeEpoch\": 1677582000,\r\n     \"temp\": 0,\r\n     \"feelslike\": -3.2,\r\n     \"humidity\": 69.05,\r\n     \"dew\": -5,\r\n     \"precip\": 0,\r\n     \"precipprob\": 0,\r\n     \"snow\": 0,\r\n     \"snowdepth\": 3.9,\r\n     \"preciptype\": null,\r\n     \"windgust\": 22.3,\r\n     \"windspeed\": 9.4,\r\n     \"winddir\": 350,\r\n     \"pressure\": 1022,\r\n     \"visibility\": 10,\r\n     \"cloudcover\": 50,\r\n     \"solarradiation\": 140,\r\n     \"solarenergy\": 0.5,\r\n     \"uvindex\": 1,\r\n     \"severerisk\": 10,\r\n     \"conditions\": \"Partially cloudy\",\r\n     \"icon\": \"partly-cloudy-day\",\r\n     \"stations\": [\r\n      \"LSZR\",\r\n      \"AT546\"\r\n     ],\r\n     \"source\": \"obs\"\r\n    },\r\n    {\r\n     \"datetime\": \"13:00:00\",\r\n     \"datetimeEpoch\": 1677585600,\r\n     \"temp\": 1,\r\n     \"feelslike\": 1,\r\n     \"humidity\": 69.26,\r\n     \"dew\": -4,\r\n     \"precip\": 0,\r\n     \"precipprob\": 0,\r\n     \"snow\": 0,\r\n     \"snowdepth\": 3.7,\r\n     \"preciptype\": null,\r\n     \"windgust\": 23.4,\r\n     \"windspeed\": 7.9,\r\n     \"winddir\": 0.2,\r\n     \"pressure\": 1022,\r\n     \"visibility\": 10,\r\n     \"cloudcover\": 50,\r\n     \"solarradiation\": 115,\r\n     \"solarenergy\": 0.4,\r\n     \"uvindex\": 1,\r\n     \"severerisk\": 10,\r\n     \"conditions\": \"Partially cloudy\",\r\n     \"icon\": \"partly-cloudy-day\",\r\n     \"stations\": [\r\n      \"LSZR\",\r\n      \"AT546\"\r\n     ],\r\n     \"source\": \"obs\"\r\n    }\r\n   ]\r\n  }\r\n ],\r\n \"alerts\": [],\r\n \"stations\": {\r\n  \"EDNY\": {\r\n   \"distance\": 29060,\r\n   \"latitude\": 47.67,\r\n   \"longitude\": 9.52,\r\n   \"useCount\": 0,\r\n   \"id\": \"EDNY\",\r\n   \"name\": \"EDNY\",\r\n   \"quality\": 50,\r\n   \"contribution\": 0\r\n  },\r\n  \"LSZR\": {\r\n   \"distance\": 10130,\r\n   \"latitude\": 47.48,\r\n   \"longitude\": 9.55,\r\n   \"useCount\": 0,\r\n   \"id\": \"LSZR\",\r\n   \"name\": \"LSZR\",\r\n   \"quality\": 50,\r\n   \"contribution\": 0\r\n  },\r\n  \"AT546\": {\r\n   \"distance\": 46923,\r\n   \"latitude\": 47.652,\r\n   \"longitude\": 9.132,\r\n   \"useCount\": 0,\r\n   \"id\": \"AT546\",\r\n   \"name\": \"HB9KNR Tagerwilen CH\",\r\n   \"quality\": 0,\r\n   \"contribution\": 0\r\n  },\r\n  \"EDJA\": {\r\n   \"distance\": 75041,\r\n   \"latitude\": 47.98,\r\n   \"longitude\": 10.23,\r\n   \"useCount\": 0,\r\n   \"id\": \"EDJA\",\r\n   \"name\": \"EDJA\",\r\n   \"quality\": 50,\r\n   \"contribution\": 0\r\n  }\r\n },\r\n \"currentConditions\": {\r\n  \"datetime\": \"18:50:00\",\r\n  \"datetimeEpoch\": 1677606600,\r\n  \"temp\": 0.7,\r\n  \"feelslike\": 0.7,\r\n  \"humidity\": 74.7,\r\n  \"dew\": -3.3,\r\n  \"precip\": 0,\r\n  \"precipprob\": 0,\r\n  \"snow\": 0,\r\n  \"snowdepth\": 0,\r\n  \"preciptype\": null,\r\n  \"windgust\": null,\r\n  \"windspeed\": 1.8,\r\n  \"winddir\": 338.8,\r\n  \"pressure\": 1023,\r\n  \"visibility\": 10,\r\n  \"cloudcover\": 88,\r\n  \"solarradiation\": 0,\r\n  \"solarenergy\": null,\r\n  \"uvindex\": 0,\r\n  \"conditions\": \"Partially cloudy\",\r\n  \"icon\": \"partly-cloudy-night\",\r\n  \"stations\": [\r\n   \"EDJA\",\r\n   \"EDNY\",\r\n   \"LSZR\"\r\n  ],\r\n  \"source\": \"obs\",\r\n  \"sunrise\": \"07:04:22\",\r\n  \"sunriseEpoch\": 1677564262,\r\n  \"sunset\": \"18:04:20\",\r\n  \"sunsetEpoch\": 1677603860,\r\n  \"moonphase\": 0.27\r\n }\r\n}";
            //var forecast = Temperatures.FromJson(returnValue);
        }

        private async Task LoadData()
        {
            resultString = await GetOnlineWeatherData();
        }

        private async Task<string> GetOnlineWeatherData()
        {
            string apiCall = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/Dornbirn?unitGroup=metric&key=32EX63L2ECJ7ZZKX6LHAF3KW5&contentType=json";
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(apiCall);
            return response;
        
        }
    }
}
