using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Swd.Bsp.Binding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Swd.Bsp.Binding.ViewModel
{
    public class fForecastViewModel : ObservableObject

    {

        //Fields
        private int _minDaysForForecast = 1;
        private int _maxDaysForForecast = 10;

        //Properties
        public bool IsDegree { get; set; }
        public List<int> DaysForForecast { get; set; }
        public List<Forecast> ForecastList { get; set; }

        //Commands
        public ICommand ShowForecastCommand { get; }
        public ICommand LoadForecastCommand { get; }
        public ICommand CloseCommand { get; }


        public fForecastViewModel()
        {
            this.IsDegree= true;

            CloseCommand = new RelayCommand(CloseView);
            DaysForForecast = BuildDaysForForecastList(_minDaysForForecast, _maxDaysForForecast);
        }

        //Methodes
        private void CloseView()
        {
            MessageBox.Show("Close");
        }

        private List<int> BuildDaysForForecastList(int _minDaysForForecast, int _maxDaysForForecast)
        {
            return Enumerable.Range(_minDaysForForecast,_maxDaysForForecast).ToList();
        }

        private void GetForecast()
        {
            
            List<Forecast> forecasts= new List<Forecast>(); 
            //int daysForForecast = (int)this.cbxDays.SelectedItem;
            int daysForForecast = 5;

            Random random = new Random();

            for (int i = 0; i < daysForForecast; i++)
            {
                Forecast forecast = new Forecast
                {
                    GeneralForecast = (GeneralForecast)random.Next(Enum.GetValues(typeof(GeneralForecast)).Length),
                    //TemperatureLow = 0,
                    //TemperatureHigh = 20,
                };
                forecasts.Add(forecast);
            }

            ForecastList = forecasts;
        }



    }
}
