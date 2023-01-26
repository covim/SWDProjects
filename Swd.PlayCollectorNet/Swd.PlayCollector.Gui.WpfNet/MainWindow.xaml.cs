using Swd.PlayCollector.DataNet;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;

namespace Swd.PlayCollector.Gui.WpfNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Location loc = new Location();
            loc.Name = "Testlocation";

            Swd.PlayCollector.DataNet.PlayCollector model = new Swd.PlayCollector.DataNet.PlayCollector();
            model.Locations.Add(loc);
        }
    }
}
