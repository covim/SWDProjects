using System;
using System.Collections.Generic;
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
    /// Interaction logic for fObjectBinding.xaml
    /// </summary>
    public partial class fObjectBinding : Window
    {

        private Window _callerWindow;

        public Window CallerWindow
        {
            get { return _callerWindow; }
            set { _callerWindow = value; }
        }
        public fObjectBinding()
        {
            InitializeComponent();
        }

        public fObjectBinding(Window callerWindow) : this()
        {
            _callerWindow = CallerWindow;
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
    }
}
