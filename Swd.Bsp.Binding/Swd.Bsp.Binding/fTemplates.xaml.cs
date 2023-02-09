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
    public partial class fTemplates : Window
    {

        private Window _callerWindow;
        private ObservableCollection<Customer> _customerList;

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

        public fTemplates()
        {
            InitializeComponent();
        }

        public fTemplates(Window callerWindow) : this()
        {
            CallerWindow = callerWindow;
            CustomerList = new ObservableCollection<Customer>
            {
                new Customer { Name = "Matthias", Email = "email1@net.com", PhoneNumber = "123", Id = 1 },
            new Customer { Name = "Gustav", Email = "email2@net.com", PhoneNumber = "456", Id = 2 },
            new Customer { Name = "Karl", Email = "email3@net.com", PhoneNumber = "789", Id = 3 }
            };

            
            lstCustomer.ItemsSource = CustomerList;
        }

        private void btnGetCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer { Name = "Matthias", Email = "email@net.com", PhoneNumber = "557896", Id = 1 };
            this.DataContext= customer;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            CallerWindow.Show();
            this.Close();
        }

        private void btnTemplate_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            MessageBox.Show((lstCustomer.SelectedItem as Customer).PhoneNumber.ToString()); //hier besser einen tag verwenden!!
            
        }
    }
}
