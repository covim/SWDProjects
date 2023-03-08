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
    /// Interaction logic for fBasicBinding.xaml
    /// </summary>
    public partial class fBasicBinding : Window
    {
        private Window _callerWindow;

        public Window CallerWindow
        {
            get { return _callerWindow; }
            set { _callerWindow = value; }
        }

        public fBasicBinding()
        {
            InitializeComponent();

        }

        public fBasicBinding(Window callerWindow) : this()
        {
            _callerWindow = CallerWindow;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            CallerWindow.Show();
            this.Close();
        }
    }
}
