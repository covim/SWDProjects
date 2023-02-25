using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace Swd.Bsp.Binding
{

    /// <summary>
    /// Interaction logic for fTemplates.xaml
    /// </summary>
    public partial class fForecast : Window
    {

        private Window _callerWindow;
        private ObservableCollection<Customer> _customerList;
        public bool IsDegree { get; set; }
        private int _minDaysForForecast = 1;
        private int _maxDaysForForecast = 10;

        public List<int> NumberOfForcastDays { get; set; }




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
            this.IsDegree = true;
            this.DataContext = this;

            //Variante 3:
            //NumberOfForcastDays = new List<int>();

            //for (int i = _minDaysForForecast; i <= _maxDaysForForecast; i++)
            //{
            //    NumberOfForcastDays.Add(i);
            //}

            //Variante 4:
            NumberOfForcastDays = Enumerable.Range(_minDaysForForecast, _maxDaysForForecast).ToList();
        }

        public fForecast(Window callerWindow) : this()
        {
            CallerWindow = callerWindow;

        }

        private void btnShowForecast_Click(object sender, RoutedEventArgs e)
        {
           
            int daysForForecast = (int)this.cbxDays.SelectedItem;          

            this.lstForecast.DataContext = GetForcastList(daysForForecast);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //Variante 1: Comboboxitems zu Liste hinzufügen
            //for (int i = _minDaysForForecast; i <= _maxDaysForForecast; i++)
            //{
            //    ComboBoxItem item = new ComboBoxItem();
            //    item.Content = i;
            //    this.cbxDays.Items.Add(item);
            //}

            //Varinate 2:
            //List<int> days = new List<int>();
            //for (int i = _minDaysForForecast; i <= _maxDaysForForecast; i++)
            //{
            //    days.Add(i);
            //}
            //this.cbxDays.ItemsSource = days;

        }

        private List<Forecast> GetForcastList(int forcastDaysCount)
        {
            List<Forecast> forecasts = new List<Forecast>();
            Random random = new Random();

            for (int i = 0; i < forcastDaysCount; i++)
            {
                Forecast forecast = new Forecast
                {
                    GeneralForecast = (GeneralForecast)random.Next(Enum.GetValues(typeof(GeneralForecast)).Length),
                    //TemperatureLow = 0,
                    //TemperatureHigh = 20,
                };
                forecasts.Add(forecast);
            }

            return forecasts;

        }
    }
}
