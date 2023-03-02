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
        // siehe CommunityToolkit 

        //Fields
        private int _minDaysForForecast = 1;
        private int _maxDaysForForecast = 10;
        private bool _isDegree;
        private List<Forecast> _forecastList = new List<Forecast>();
        private List<int> _daysForForecast;
        private int _selectedDays;




        //Properties

        public int SelectedDays
        {
            get { return _selectedDays; }
            set
            {
                SetProperty(ref _selectedDays, value);
                GetForecast();

            }
        }

        public bool IsDegree
        {
            get { return _isDegree; }
            set
            {
                SetProperty(ref _isDegree, value);
            }
        }
        public List<int> DaysForForecast
        {
            get { return _daysForForecast; }
            set
            {
                SetProperty(ref _daysForForecast, value);
            }
        }
        public List<Forecast> ForecastList
        {
            get { return _forecastList; }
            set
            {
                SetProperty(ref _forecastList, value);
            }
        }

        //Commands
        public ICommand ShowForecastCommand { get; }
        public ICommand LoadForecastCommand { get; }
        public ICommand CloseCommand { get; }


        public fForecastViewModel()
        {
            this.IsDegree = true;
            this._selectedDays = 5;

            CloseCommand = new RelayCommand(CloseView);
            ShowForecastCommand = new RelayCommand(ShowForecast);
            DaysForForecast = BuildDaysForForecastList(_minDaysForForecast, _maxDaysForForecast);
        }

        //Methodes
        private void CloseView()
        {
            MessageBox.Show("Close");
        }

        private void ShowForecast()
        {
            GetForecast();
        }

        private List<int> BuildDaysForForecastList(int _minDaysForForecast, int _maxDaysForForecast)
        {
            return Enumerable.Range(_minDaysForForecast, _maxDaysForForecast).ToList();
        }

        private void GetForecast()
        {

            List<Forecast> forecasts = new List<Forecast>();
            //int daysForForecast = (int)this.cbxDays.SelectedItem;
            int daysForForecast = SelectedDays;

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
